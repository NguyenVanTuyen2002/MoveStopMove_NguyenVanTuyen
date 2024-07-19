using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    public VariableJoystick joystick;

    private Vector3 _movement;

    private void Start()
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetOwner(this); // Thiết lập chủ sở hữu cho vũ khí
        }
    }

    private void Update()
    {
        Move();
        Rotate();

        /*if (HaveCharacterInAttackRange())
        {
            // Nếu target không phải là null, tiếp tục tấn công
            AttackCharacterInRange();
        }
        if (target == null)
        {
            
        }*/
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
            if (HaveCharacterInAttackRange())
            {
                if (isDead == false)
                {
                    AttackCharacterInRange();
                }
                else
                {
                    CharacterOnDead(this);
                }
            }
            else
            {
                ChangeAnim(CacheString.Anim_Idle);
            }
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

    public override void FindTarget()
    {
        /*if (listAttack.Count <= 0) return;
        target = listAttack[0];*/
        base.FindTarget();

        foreach (var i in listAttack)
        {
            i.HideRendererTarget();
            if (i == target)
            {
                i.ShowRendererTarget();
            }
        }
    }

    public void CharacterOnDead(Character chart)
    {
        StartCoroutine(CoCharacterOnDead(chart));
    }

    public override IEnumerator CoCharacterOnDead(Character chart)
    {
        isDead = true;
        ChangeAnim(CacheString.Anim_Dead);
        yield return new WaitForSeconds(0.8f);
        chart.gameObject.SetActive(false);
        OnDeathAction?.Invoke();
    }
}