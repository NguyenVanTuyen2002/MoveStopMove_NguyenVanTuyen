using System.Collections;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        
    }

    public void OnExecute(Bot t)
    {
        if (t.HaveCharacterInAttackRange())
        {
            t.AttackCharacterInRange();
        }
        else
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot t)
    {
        
    }
}