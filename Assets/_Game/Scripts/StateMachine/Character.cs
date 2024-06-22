using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : GameUnit
{
    public string currentAnimName;
    public Animator anim;
    private IEnumerator ieReAppearWeapon;
    private UnityAction demo;
    private UnityAction ExitAtkRange;

    public void Attack()
    {
        StopCoroutine(ieReAppearWeapon);
        ieReAppearWeapon = CoReAppearWeapon();
        StartCoroutine(CoReAppearWeapon());
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    private void RemoveTarget(Character character)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {

            ExitAtkRange +=  RemoveTarget()
        }
    }

    public IEnumerator CoReAppearWeapon()
    {
        yield return null;
    }
}
