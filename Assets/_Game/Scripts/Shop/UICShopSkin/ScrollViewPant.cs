using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewPant : MonoBehaviour
{
    public Transform ShopContent;
    public ItemShop itemShopPrefab;
    public ShopDataConfig shopDataConfig;
    public List<ItemShop> itemShopList = new List<ItemShop>();

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        for (int i = 0; i < shopDataConfig.pantDatas.Count; i++)
        {
            PantData data = shopDataConfig.pantDatas[i];

            ItemShop itemShop = Instantiate(itemShopPrefab, ShopContent);
            itemShopList.Add(itemShop);
            itemShop.SetUp(data);
        }
    }
}