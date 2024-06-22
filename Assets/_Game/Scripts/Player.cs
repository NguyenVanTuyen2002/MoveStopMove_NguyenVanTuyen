using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Weapon weaponPrefabs;
    [SerializeField] private Transform attackPoint;

    public VariableJoystick joystick;
    //public Vector3 posRaycast;


    private Vector3 _movement;

    private void Update()
    {
        Vector3 posRaycast = attackPoint.position;

        Move();
        Rotate();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ChangeAnim(CacheString.Anim_Attack);
        }
        Debug.DrawRay(posRaycast, Vector3.forward * 5f, UnityEngine.Color.red);
    }

    private void Move()
    {
        _movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (_movement.sqrMagnitude > 0.1f)
        {
            transform.Translate(_moveSpeed * Time.deltaTime * _movement, Space.World);
            ChangeAnim(CacheString.Anim_Run);
        }
        else if (_movement.sqrMagnitude < 0.1f)
        {
            ChangeAnim(CacheString.Anim_Idle);
        }
    }

    private void Rotate()
    {
        Vector2 look = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (look.sqrMagnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * _rotationSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    
    
}
