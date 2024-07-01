using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : GameUnit
{
    [SerializeField] public List<Character> listAttack = new List<Character>();
    [SerializeField] protected Renderer targetRenderer;
    [SerializeField] protected Character target;

    protected bool isMoving;

    public string currentAnimName;
    public Animator anim;
    public Transform attackPoint;
    public Bullet bulletPrefab;

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    public void Attack()
    {
        if (target != null && bulletPrefab != null)
        {
            Bullet bulletObject = SimplePool.Spawn<Bullet>(bulletPrefab, attackPoint.position, bulletPrefab.transform.rotation);
            StartCoroutine(bulletObject.CoMoveBullet(bulletObject, target.transform.position));
        }
    }

    protected IEnumerator CoAttack()
    {
        while (true)
        {
            if (listAttack.Count > 0 && !isMoving)
            {
                Debug.Log(listAttack.Count);
                Attack();
                Debug.Log("danh");
            }
            yield return new WaitForSeconds(2f); // Tạm dừng 2 giây trước khi lặp lại
        }
    }

    public void AddToAttackList(Character character)
    {
        if (!listAttack.Contains(character))
        {
            listAttack.Add(character);
        }
    }

    public void RemoveFromAttackList(Character character)
    {
        if (listAttack.Contains(character))
        {
            listAttack.Remove(character);
            target = null;
        }
    }

    public void ShowRendererTarget()
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = true;
        }
    }

    public void HideRendererTarget()
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = false;
        }
    }

    protected virtual void FindTarget()
    {
        if (listAttack.Count <= 0) return;
        target = listAttack[0];
    }



}