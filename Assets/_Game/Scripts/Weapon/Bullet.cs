﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : GameUnit
{
    [SerializeField] private Character owner;

    public float rotationSpeed = 360f;
    public float moveSpeed = 5f; // Bạn có thể điều chỉnh tốc độ di chuyển của đạn.

    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float startTime;
    private float journeyLength;
    private bool isMoving = false;
    private bool isDead;

    private void Update()
    {
        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            RotateBullet();

            if (fractionOfJourney >= 1)
            {
                isMoving = false;
                OnDespawn();
            }
        }
    }

    public void SetTargetPosition(Vector3 startPosition, Vector3 targetPosition, Character owner)
    {
        this.startPosition = startPosition;
        this.targetPosition = targetPosition;
        this.owner = owner;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
        isMoving = true;
    }

    private void RotateBullet()
    {
         transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public void CollisionWithCharacter(Collider other)
    {
        if (!other.CompareTag(CacheString.Tag_Character)) return;
        Character character = CacheComponent.GetCharacter(other);
        if (character != owner)
        {
            character.SetDead();
            (character as Bot).ChangeState(new DieState());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionWithCharacter(other);
    }
}