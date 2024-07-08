using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    public void Fire(Vector3 firePosition, Vector3 targetPosition)
    {
        Bullet bulletObject = SimplePool.Spawn<Bullet>(bulletPrefab, firePosition, Quaternion.identity);
        bulletObject.SetTargetPosition(firePosition, targetPosition);
        Debug.Log("Fire");
    }
}