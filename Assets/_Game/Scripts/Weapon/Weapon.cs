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
        bulletObject.gameObject.SetActive(true);
        //StartCoroutine(bulletObject.CoMoveBullet(bulletObject, targetPosition));
        bulletObject.SetTargetPosition(firePosition, targetPosition);
        Debug.Log("Fire");
    }
}
