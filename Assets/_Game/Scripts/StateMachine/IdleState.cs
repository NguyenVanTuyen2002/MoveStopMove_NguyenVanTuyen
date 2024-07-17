using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    float timer;
    float randomTime;

    public void OnEnter(Bot t)
    {
        timer = 0;
        randomTime = Random.Range(1f, 5f); // Thời gian bot đứng yên
        timer += Time.deltaTime;
        t.ChangeAnim(CacheString.Anim_Idle);
        t.Move();
    }

    public void OnExecute(Bot t)
    {
        timer += Time.deltaTime;

        if (timer >= randomTime || !t.HaveCharacterInAttackRange())
        {
            t.ChangeState(new PatrolState());
        }
        else
        {
            t.ChangeState(new AttackState());
        }
    }

    public void OnExit(Bot t)
    {

    }
}