using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : UICanvas
{
    [SerializeField] private ScrollViewHair scrollHair;
    [SerializeField] private ScrollViewPant scrollPant;
    [SerializeField] private ScrollViewShield scrollShield;
    [SerializeField] private ScrollViewSet scrollSet;

    public Button BtnShopSkinHair;
    public Button BtnShopSkinClothes;
    public Button BtnShopSkinAmor;
    public Button BtnShopSkinSetFull;
    public Button CloseButton;

    public void ExitButton()
    {
        GameManager.ChangeState(GameState.MainMenu);
        UIManager.Ins.OpenUI<MianMenu>();
        //LevelManager.Ins.playerCtl.ChangeSkinPlayer.LoadSkin();
        //LevelManager.Ins.playerCtl.IsActiveSkin(true);
        Close(0);
    }

    public void BtnSelectHair()
    {
        /*scrollRect.content = content_Hair.GetComponent<RectTransform>();
        idSkin = (int)Skin.Hair;
        if (PlayerPrefs.GetInt(Constants.CURRENT_SKIN) == idSkin && PlayerPrefs.GetInt(Constants.CURRENT_HAIR) != 0)
        {
            id = PlayerPrefs.GetInt(Constants.CURRENT_HAIR);
        }
        else
        {
            id = 1;
        }*/
        scrollHair.gameObject.SetActive(true);
        scrollPant.gameObject.SetActive(false);
        scrollShield.gameObject.SetActive(false);
        scrollSet.gameObject.SetActive(false);
        
        //LoadButton();
        //LevelManager.Ins.playerCtl.IsActiveSkin(false);
        //LevelManager.Ins.playerCtl.ChangeSkinPlayer.DelTestSkin();

    }
    public void BtnSelectShield()
    {
        scrollHair.gameObject.SetActive(false);
        scrollPant.gameObject.SetActive(false);
        scrollShield.gameObject.SetActive(true);
        scrollSet.gameObject.SetActive(false);

        /*scrollRect.content = content_Shield.GetComponent<RectTransform>();
        idSkin = (int)Skin.Shiel;
        if (PlayerPrefs.GetInt(Constants.CURRENT_SKIN) == idSkin && PlayerPrefs.GetInt(Constants.CURRENT_SHIELD) != 0)
        {
            id = PlayerPrefs.GetInt(Constants.CURRENT_SHIELD);
        }
        else
        {
            id = 1;
        }
        content_Hair.SetActive(false);
        content_Shield.SetActive(true);
        content_Set.SetActive(false);
        content_Pant.SetActive(false);
        LoadButton();
        LevelManager.Ins.playerCtl.IsActiveSkin(false);
        LevelManager.Ins.playerCtl.ChangeSkinPlayer.DelTestSkin();*/
    }
    public void BtnSelectPant()
    {
        scrollHair.gameObject.SetActive(false);
        scrollPant.gameObject.SetActive(true);
        scrollShield.gameObject.SetActive(false);
        scrollSet.gameObject.SetActive(false);

        /*scrollRect.content = content_Pant.GetComponent<RectTransform>();
        idSkin = (int)Skin.Pant;
        if (PlayerPrefs.GetInt(Constants.CURRENT_SKIN) == idSkin && PlayerPrefs.GetInt(Constants.CURRENT_PANT) != 0)
        {
            id = PlayerPrefs.GetInt(Constants.CURRENT_PANT);
        }
        else
        {
            id = 1;
        }
        content_Hair.SetActive(false);
        content_Shield.SetActive(false);
        content_Set.SetActive(false);
        content_Pant.SetActive(true);
        LoadButton();
        LevelManager.Ins.playerCtl.IsActiveSkin(false);
        LevelManager.Ins.playerCtl.ChangeSkinPlayer.DelTestSkin();*/
    }
    public void BtnSelectSet()
    {
        scrollHair.gameObject.SetActive(false);
        scrollPant.gameObject.SetActive(false);
        scrollShield.gameObject.SetActive(false);
        scrollSet.gameObject.SetActive(true);

        /*scrollRect.content = content_Set.GetComponent<RectTransform>();
        idSkin = (int)Skin.Set;
        if (PlayerPrefs.GetInt(Constants.CURRENT_SKIN) == idSkin && PlayerPrefs.GetInt(Constants.CURRENT_SET) != 0)
        {
            id = PlayerPrefs.GetInt(Constants.CURRENT_SET);
        }
        else
        {
            id = 1;
        }
        content_Hair.SetActive(false);
        content_Shield.SetActive(false);
        content_Set.SetActive(true);
        content_Pant.SetActive(false);
        LoadButton();
        LevelManager.Ins.playerCtl.IsActiveSkin(false);
        LevelManager.Ins.playerCtl.ChangeSkinPlayer.DelTestSkin();*/
    }
}
