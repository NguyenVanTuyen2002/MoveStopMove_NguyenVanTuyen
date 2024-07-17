using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] List<Transform> listTfSpawnCrt;

    public List<Bot> bots;
    public float spawnRadius = 1f; // Bán kính sinh bot ngẫu nhiên

    private void Start()
    {
        SpawnBotBegin();
    }

    public void SpawnBotBegin()
    {
        for (int i = 0; i < listTfSpawnCrt.Count - 1; i++)
        {
            // Tạo bot từ pool
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot);
            bot.gameObject.SetActive(false);
            bots.Add(bot);
            Transform spawnPoint = listTfSpawnCrt[i];
            bot.TF.position = spawnPoint.position;
            bot.gameObject.SetActive(true);
        }
    }
}
