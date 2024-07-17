using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackRange : MonoBehaviour
{
    public Character owner;

    private Dictionary<Character, Coroutine> attackCoroutines = new Dictionary<Character, Coroutine>();

    public void CharacterGetInList(Collider other)
    {
        if (!other.CompareTag(CacheString.Tag_Character)) return;
        Character characters = CacheComponent.GetCharacter(other);
        if (characters != null && characters != owner)
        {
            owner.AddToAttackList(characters);
            owner.FindTarget();
            // Notify bot that it entered the attack range
            Bot bot = characters as Bot;
            if (bot != null)
            {
                bot.OnEnterAttackRange(owner);
                //bot.FindTarget();
            }

            Player player = characters as Player;
            if (player != null)
            {
                player.FindTarget();
            }
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
            //characters.StopAttackCoroutine();
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