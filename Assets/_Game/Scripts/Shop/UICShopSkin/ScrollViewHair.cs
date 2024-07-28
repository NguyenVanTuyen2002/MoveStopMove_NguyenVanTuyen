using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIBaseScrollView;

public class ScrollViewHair : UIBaseScrollView, IScrollViews
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
        for (int i = 0; i < shopDataConfig.hairDatas.Count; i++)
        {
            HairData data = shopDataConfig.hairDatas[i];

            ItemShop itemShop = Instantiate(itemShopPrefab, ShopContent);
            itemShopList.Add(itemShop);
            itemShop.SetUp(data);
        }
    }

    public override void DemoItem()
    {
        base.DemoItem();
        LevelManager.Ins.currentMap.demoCharacter.ChangeSkinHair(IDItem);
    }
}