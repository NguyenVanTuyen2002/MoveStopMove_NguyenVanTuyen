using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ItemShop : UIBaseItemShop
{
    public Button BtnSelect;
    public Image ImageLock;
    public Image ImageIcon;
    public Image ImgLine;
    public Image background;
    public Image ImageEquipped;
    //public static List<ItemShop> allItemShops = new List<ItemShop>();

    private UIBaseScrollView parentScrollView;
    private Color originalColor;


    /*private void Awake()
    {
        // Thêm đối tượng hiện tại vào danh sách
        allItemShops.Add(this);
    }*/

    public void SetUp(HairData data)
    {
        ImageIcon.sprite = data.Icon;
    }
    
    public void SetUp(PantData data)
    {
        ImageIcon.sprite = data.Icon;
    }
    
    public void SetUp(ShieldData data)
    {
        ImageIcon.sprite = data.Icon;
    }
    
    public void SetUp(SetData data)
    {
        ImageIcon.sprite = data.Icon;
    }

    public void OnBtnSelectClick()
    {
        /*if (parentScrollView is UIScrollViewsSetFull setFullScrollView)
        {
            setFullScrollView.TxtDescription.gameObject.SetActive(true);
            setFullScrollView.TxtDescription.text = baseData.Description;
        }
        parentScrollView.OnItemSelected(baseData.ID, baseData.Price);
        parentScrollView.CheckButton()*/;
        parentScrollView.DemoItem();
        EffectOnclickButton();
    }

    private void EffectOnclickButton()
    {
        parentScrollView.RemoveGlowFromAllItems();
        HighlightItem();
    }

    public void ResetGlow()
    {
        if (background != null)
        {
            background.color = originalColor;
        }
        ImgLine.gameObject.SetActive(false);
    }

    private void HighlightItem()
    {
        if (background != null)
        {
            background.color = Color.white;
        }
        ImgLine.gameObject.SetActive(true);
    }

    /*public void BtnTest()
    {
        // Đặt lại trạng thái cho tất cả các đối tượng khác
        foreach (var itemShop in allItemShops)
        {
            if (itemShop != this)
            {
                itemShop.ImageSelect.gameObject.SetActive(false);
                itemShop.ImageBG.gameObject.SetActive(true);
            }
        }

        // Thiết lập trạng thái cho đối tượng hiện tại
        ImageSelect.gameObject.SetActive(true);
        ImageBG.gameObject.SetActive(false);
    }*/
}