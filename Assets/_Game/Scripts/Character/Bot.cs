using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private NavMeshAgent agent;

    public float _moveRadius = 10f; // Bán kính di chuyển ngẫu nhiên

    private float timer;
    private float idleTimer = 0f;
    private float currentIdleDuration;

    void Start()
    {
        currentIdleDuration = Random.Range(1f, 5f);
        /*StartCoroutine(CoAttack());*/
    }

    void Update()
    {
        Move();
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

    

}