using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.CharacterOnDead(t);
        Debug.Log("di�tate");
    }

    public void OnExecute(Bot t)
    {
        
    }

    public void OnExit(Bot t)
    {

    }
}
