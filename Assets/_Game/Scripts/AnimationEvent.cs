using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{      
    [SerializeField] private Weapon weapon;

    public void DeActiveWeapon()
    {
        weapon.gameObject.SetActive(false);
        Debug.Log("TurnOff Weapon");
    }

    public void SetActiveWeapon()
    {
        weapon.gameObject.SetActive(true);
        Debug.Log("TurnOn Weapon");
    }
}
