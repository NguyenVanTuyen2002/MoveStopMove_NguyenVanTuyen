using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.TextCore.Text;

public class Bot : Character
{
    [SerializeField] public NavMeshAgent agent;

    public float _moveRadius = 10f; // Bán kính di chuyển ngẫu nhiên
    public float attackRange = 2f;
    public float huntRange = 15f;

    private float timer;
    private float idleTimer = 0f;
    private float currentIdleDuration;
    private IState<Bot> _currentState;

    private void Start()
    {
        currentIdleDuration = Random.Range(1f, 5f);

        isDead = false;

        ChangeState(new IdleState());

        if (currentWeapon != null)
        {
            currentWeapon.SetOwner(this); // Thiết lập chủ sở hữu cho vũ khí
        }
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Bot> state)
    {
        if (_currentState != null)
        {
            _currentState.OnExit(this);
        }

        _currentState = state;

        if (_currentState != null)
        {
            _currentState.OnEnter(this);
        }
    }

    public void OnInit()
    {
        this.isDead = false;
        /*this.listAttack.Clear();
        this.target = null;*/
        //ChangeState(new IdleState());
    }

    public void Move()
    {
        timer += Time.deltaTime;

        if (agent.velocity.magnitude > 0.1f)
        {
            if (!isMoving)
            {
                isMoving = true;
                idleTimer = 0f; // Reset bộ đếm thời gian Idle khi bắt đầu di chuyển
                ChangeAnim(CacheString.Anim_Run);
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                ChangeAnim(CacheString.Anim_Idle);
                currentIdleDuration = Random.Range(1f, 5f);
            }

            idleTimer += Time.deltaTime;

            if (idleTimer >= currentIdleDuration)
            {
                Vector3 newPos = RandomNavSphere(transform.position, _moveRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
                idleTimer = 0f; // Reset bộ đếm thời gian Idle khi bắt đầu di chuyển mới
            }
        }
    }    

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    public void OnEnterAttackRange(Character target)
    {
        agent.ResetPath();
        isMoving = false;
        ChangeAnim(CacheString.Anim_Idle);
        //ChangeState(new AttackState());
    }

    public void DespawnBot()
    {
        SimplePool.Despawn(this);
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
        DespawnBot();
        OnDeathAction?.Invoke();
        LevelManager.Ins.currentLevel.RemoveBotWhenDead(this);
    }

    /*public void Hunt()
    {
        Character closestCharacter = LevelManager.Ins.GetClosestCharacter(this);
        if (closestCharacter != null)
        {
            float distance = Vector3.Distance(transform.position, closestCharacter.transform.position);
            if (distance > huntRange)
            {
                ChangeAnim(CacheString.Anim_Run);
                agent.SetDestination(closestCharacter.transform.position);
            }
            else
            {
                Debug.Log("stop => attack");
                ChangeAnim(CacheString.Anim_Idle);
                //AddToAttackList(closestCharacter);
                agent.ResetPath();
                //ChangeState(new AttackState());
            }
        }
    }*/
}