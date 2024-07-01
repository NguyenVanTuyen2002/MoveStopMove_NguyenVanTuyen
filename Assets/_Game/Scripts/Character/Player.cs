using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Weapon weaponPrefabs;

    public VariableJoystick joystick;

    private Vector3 _movement;

    private void Start()
    {
        StartCoroutine(CoAttack());
    }

    private void Update()
    {
        Move();
        Rotate();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ChangeAnim(CacheString.Anim_Attack);
            Attack();
        }
        FindTarget();
    }

    private void Move()
    {
        _movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (_movement.sqrMagnitude > 0.1f)
        {
            isMoving = true;
            transform.Translate(_moveSpeed * Time.deltaTime * _movement, Space.World);
            ChangeAnim(CacheString.Anim_Run);
        }
        else if (_movement.sqrMagnitude < 0.1f)
        {
            isMoving = false;
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

    protected override void FindTarget()
    {
        base.FindTarget();
        foreach(var i in listAttack)
        {
            i.HideRendererTarget();
            if(i == target)
            {
                i.ShowRendererTarget();
            }
        }
    }
}