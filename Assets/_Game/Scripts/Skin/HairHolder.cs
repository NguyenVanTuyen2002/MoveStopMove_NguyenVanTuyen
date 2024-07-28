using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.Playables;

//public class HairHolder : MonoBehaviour
//{
//    [SerializeField] private Character owner;

//    public HairSkinObj currentHairtest;
//    public void HairTest(int id)
//    {
//        if (owner.CurrentHair != null) owner.CurrentHair.gameObject.SetActive(false);
//        if (currentHairtest != null) Destroy(currentHairtest.gameObject);
//        HairSkinObj hair = Instantiate(ShopSkinData.GetHairSkinObjBuyId(id), transform);
//        currentHairtest = hair;
//        //hair.OnInit();
//    }
//}