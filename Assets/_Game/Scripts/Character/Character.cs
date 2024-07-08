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
    [SerializeField] private Weapon currentWeapon;

    protected bool isMoving;

    public string currentAnimName;
    public Animator anim;
    public Transform attackPoint;

    /*private Dictionary<Character, float> attackTimers = new Dictionary<Character, float>();
    private float attackDelay = 1.5f;*/

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
        FindTarget();
        if (target != null && currentWeapon != null)
        {
            Debug.Log("att");
            currentWeapon.Fire(attackPoint.position, target.transform.position);
        }
    }

    public void AutoAttack()
    {
        if (listAttack.Count > 0)
        {

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