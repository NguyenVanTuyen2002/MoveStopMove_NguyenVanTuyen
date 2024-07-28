using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewSet : MonoBehaviour
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
        for (int i = 0; i < shopDataConfig.setDatas.Count; i++)
        {
            SetData data = shopDataConfig.setDatas[i];

            ItemShop itemShop = Instantiate(itemShopPrefab, ShopContent);
            itemShopList.Add(itemShop);
            itemShop.SetUp(data);
        }
    }
}