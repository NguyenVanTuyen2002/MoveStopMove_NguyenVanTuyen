using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Character : GameUnit
{
    [SerializeField] public List<Character> listAttack = new List<Character>();
    [SerializeField] public Character target;
    [SerializeField] protected Renderer targetRenderer;
    [SerializeField] protected Weapon currentWeapon;

    protected bool isMoving;
    protected bool isDead; // Biến theo dõi trạng thái chết của nhân vật

    public string currentAnimName;
    public Animator anim;
    public Transform attackPoint;

    private Coroutine attackCoroutine;
    protected UnityAction OnDeathAction;
    private Dictionary<Character, UnityAction> onDeathActions = new Dictionary<Character, UnityAction>();

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    /*public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName); // Reset trigger của hoạt ảnh hiện tại
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }*/

    public void Attack()
    {
        //FindTarget();
        if (target != null && currentWeapon != null)
        {
            currentWeapon.Fire(attackPoint.position, target.transform.position);
        }
    }

    public void AttackCharacterInRange()
    {
        if (attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(CoFire());
        }
    }

    public IEnumerator CoFire()
    {
        ChangeAnim(CacheString.Anim_Idle);
        yield return new WaitForSeconds(2.5f);
        if (HaveCharacterInAttackRange())
        {
            ChangeAnim(CacheString.Anim_Attack);
            yield return new WaitForSeconds(0.4f);
            currentWeapon.DeActiveWeapon();
            Attack();
            yield return new WaitForSeconds(0.8f);
            currentWeapon.SetActiveWeapon();
            //ChangeAnim(CacheString.Anim_Idle);
        }
        attackCoroutine = null; // Reset coroutine để có thể chạy lại khi cần
    }

    public void StopAttackCoroutine()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    public bool HaveCharacterInAttackRange() => listAttack.Count > 0;

    /*public virtual void CharacterOnDead(Character chart)
    {
        StartCoroutine(CoCharacterOnDead(chart));
    }*/

    public virtual IEnumerator CoCharacterOnDead(Character chart)
    {
        yield return new WaitForSeconds(0f);
        OnDeathAction?.Invoke();
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
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

    public void AddEnemyDeadAction(Character character)
    {
        UnityAction action = () => RemoveFromAttackList(character);
        character.OnDeathAction += action;
        // Store the reference to the action
        onDeathActions[character] = action;
    }
    public void RemoveEnemyDeadAction(Character character)
    {
        // tìm kiểu trong dict có enemy ko , nếu có thì trả về action của có vào biến action 
        if (onDeathActions.TryGetValue(character, out UnityAction action))
        {
            character.OnDeathAction -= action;
            onDeathActions.Remove(character);
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

    public virtual void FindTarget()
    {
        if (listAttack.Count <= 0) return;
        target = listAttack[0];
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetDead()
    {
        isDead = true;
    }
}