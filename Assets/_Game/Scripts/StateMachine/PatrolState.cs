using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    float timer;
    float randomTime;

    public void OnEnter(Bot t)
    {
        
    }

    public void OnExecute(Bot t)
    {
        if (t.HaveCharacterInAttackRange())
        {
            t.ChangeState(new AttackState());
        }
        else
        {
            t.Move();
        }
    }

    public void OnExit(Bot t)
    {

    }
}