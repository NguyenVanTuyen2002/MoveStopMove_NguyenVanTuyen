using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{      
    //[SerializeField] private Weapon weapon;
    [SerializeField] private MeshRenderer weaponRenderer;

    public void DeActiveWeapon()
    {
        weaponRenderer.enabled = false;
        Debug.Log("TurnOff Weapon");
    }

    public void SetActiveWeapon()
    {
        weaponRenderer.enabled = true;
        Debug.Log("TurnOn Weapon");
    }
}
