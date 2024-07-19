using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] List<Transform> listTfSpawnCrt;

    public List<Bot> bots;

    private int totalBot = 15;
    private int countBot;

    private void Start()
    {
        SpawnBotInit();
    }

    private void FixedUpdate()
    {
        SpawnBot();
    }

    public void SpawnBotInit()
    {
        for (int i = 0; i < listTfSpawnCrt.Count - 1; i++)
        {
            // Tạo bot từ pool
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot);
            bot.OnInit();
            bot.gameObject.SetActive(false);
            bots.Add(bot);
            Transform spawnPoint = listTfSpawnCrt[i];
            bot.TF.position = spawnPoint.position;
            bot.gameObject.SetActive(true);
            countBot ++;
        }
    }

    public void SpawnBot()
    {
        if (bots.Count < 5 && countBot <= totalBot)
        {
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot);
            bot.OnInit();
            bot.gameObject.SetActive(false);
            bots.Add(bot);
            Transform spawnPoint = listTfSpawnCrt[Random.Range(0, listTfSpawnCrt.Count)];
            bot.TF.position = spawnPoint.position;
            bot.gameObject.SetActive(true);
            countBot++;
        }
    }

    /*public void SpawnBot()
    {
        if (bots.Count <= 5 && countBot <= totalBot)
        {
            if (bots.Count < 5)
            {
                Transform spawnPoint = GetValidSpawnPoint();
                if (spawnPoint != null)
                {
                    Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot);
                    bot.gameObject.SetActive(false);
                    bots.Add(bot);
                    bot.TF.position = spawnPoint.position;
                    bot.gameObject.SetActive(true);
                    countBot++;
                }
            }
        }
    }*/

    private Transform GetValidSpawnPoint()
    {
        foreach (Transform spawnPoint in listTfSpawnCrt)
        {
            if (!IsObjectNearby(spawnPoint.position, 1f))
            {
                return spawnPoint;
            }
        }
        return null; // Không tìm thấy điểm spawn hợp lệ
    }

    private bool IsObjectNearby(Vector3 position, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != this.gameObject) // Kiểm tra xem đối tượng không phải chính nó
            {
                return true; // Có đối tượng trong bán kính
            }
        }
        return false; // Không có đối tượng nào trong bán kính
    }

    public void RemoveBotWhenDead(Bot bot)
    {
        if (bots.Contains(bot))
        {
            bots.Remove(bot);
        }
    }
}
