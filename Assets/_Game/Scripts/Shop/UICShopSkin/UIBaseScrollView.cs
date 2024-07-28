using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBaseScrollView : UICanvas
{
    public Transform shopContent;
    public ItemShop shopItem;
    public SkinShop uICShopSkin;
    public int IDItem;
    public int PriceItem;

    public Button BtnSelect;
    public Button BtnUnlock;
    public Button BtnBuy;
    public TextMeshProUGUI equipedTxt;
    public List<ItemShop> shopItems = new List<ItemShop>();

    public virtual void DemoItem()
    {

    }

    public void OnItemSelected(int itemId, int price)
    {
        IDItem = itemId;
        PriceItem = price;
    }

    public void RemoveGlowFromAllItems()
    {
        foreach (var item in shopItems)
        {
            item.ResetGlow();
        }
    }

    public void CheckButton()
    {
        /*if (IsSelectedItem())
        {
            CloseAllButton();
            equipedTxt.gameObject.SetActive(true);
        }
        else if (IsBoughtItem())
        {
            CloseAllButton();
            BtnSelect.gameObject.SetActive(true);
        }
        else
        {
            CloseAllButton();
            BtnBuy.gameObject.SetActive(true);
            BtnUnlock.gameObject.SetActive(true);
        }*/
    }

    public interface IScrollViews
    {
        void OnItemSelected(int itemId, int price);
        void RemoveGlowFromAllItems();
        void CheckButton();
    }
}