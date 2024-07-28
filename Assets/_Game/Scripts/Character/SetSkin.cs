using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour
{
    [SerializeField] private Transform hairHolder;

    private HairSkinObj hairSkinObj;

    public void ChangeHair(int ID)
    {
        HairSkinObj hairSkin = LevelManager.Ins.ShopSkinData.GetHairSkinObjBuyId(ID);
        hairSkinObj = hairSkin;
        if (hairHolder != null && hairSkinObj != null)
        {
            DelCurrentItems(hairHolder);
            HairSkinObj hairInstance = Instantiate(hairSkinObj, hairHolder.position, hairHolder.rotation);
            hairInstance.transform.SetParent(hairHolder);
        }
    }

    public void DelCurrentItems(Transform parentTransform)
    {
        if (parentTransform != null)
        {
            foreach (Transform child in parentTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
