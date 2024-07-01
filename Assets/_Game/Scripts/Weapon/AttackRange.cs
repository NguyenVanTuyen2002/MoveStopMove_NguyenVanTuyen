using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackRange : MonoBehaviour
{
    public Character owner;

    public void CharacterGetInList(Collider other)
    {
        if (!other.CompareTag(CacheString.Tag_Character)) return;
        Character characters = CacheComponent.GetCharacter(other);
        if (characters != null && characters != owner)
        {
            owner.AddToAttackList(characters);
        }
    }

    public void CharacterGetOutList(Collider other)
    {
        if (!other.CompareTag(CacheString.Tag_Character)) return;
        Character characters = CacheComponent.GetCharacter(other);
        if (characters != null && characters != owner)
        {
            owner.RemoveFromAttackList(characters);
            characters.HideRendererTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterGetInList(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterGetOutList(other);
    }
}
