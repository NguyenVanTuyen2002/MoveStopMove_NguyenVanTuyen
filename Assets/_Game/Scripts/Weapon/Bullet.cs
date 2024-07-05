using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : GameUnit
{
    private Vector3 direction;
    public float rotationSpeed = 360f;
    public float moveSpeed;

    /*public IEnumerator CoMoveBullet(Bullet bullet, Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.7f; // Thời gian để đạn di chuyển tới mục tiêu
        Vector3 startPosition = bullet.transform.position;

        while (elapsedTime < duration)
        {
            bullet.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            RotateBullet(bullet); // Gọi phương thức để xoay đạn
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bullet.transform.position = targetPosition;
        SimplePool.Despawn(bullet); // Hủy đạn khi tới mục tiêu
    }*/


    private void Update()
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
        RotateBullet();
    }

    private void RotateBullet()
    {
         transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    internal void SetTargetPosition(Vector3 firePosition, Vector3 targetPosition)
    {
        direction = (targetPosition - firePosition).normalized;
        //float elapsedTime = 0f;
        //float duration = 0.7f; // Thời gian để đạn di chuyển tới mục tiêu
        //Vector3 startPosition = bullet.transform.position;
        //while (elapsedTime < duration)
        //{
        //    bullet.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
        //    RotateBullet(bullet); // Gọi phương thức để /*xoay*/ đạn
        //    elapsedTime += Time.deltaTime;
        //    //yield return null;
        //}

        //bullet.transform.position = targetPosition;
        //SimplePool.Despawn(bullet); // Hủy đạn khi tới mục tiêu
    }


}