using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level currentLevel;

    /*public Character GetClosestCharacter(Character requester)
    {
        Character closestCharacter = null;
        float closestDistance = float.MaxValue;

        foreach (var character in FindObjectsOfType<Character>())
        {
            if (character != requester)
            {
                float distance = Vector3.Distance(requester.transform.position, character.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCharacter = character;
                }
            }
        }

        return closestCharacter;
    }*/
}