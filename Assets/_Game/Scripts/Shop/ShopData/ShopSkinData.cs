using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopSkinData", menuName = "Script able Object/ Shop Skin Data", order = 1)]
public class ShopSkinData : ScriptableObject
{
    public List<HairSkinObj> hairSkinObjs = new List<HairSkinObj>();

    public HairSkinObj GetHairSkinObjBuyId(int id)
    {
        return hairSkinObjs[id];
    }
}