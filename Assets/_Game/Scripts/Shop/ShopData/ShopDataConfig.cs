using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopDataConfig", menuName = "Script able Object/ Shop Data Config" , order = 1)]
public class ShopDataConfig : ScriptableObject
{
    public List<HairData> hairDatas = new List<HairData>();

    public List<PantData> pantDatas = new List<PantData>();

    public List<ShieldData> shieldDatas = new List<ShieldData>();

    public List<SetData> setDatas = new List<SetData>();
}

[Serializable] public class HairData
{
    public int ID;
    public string Name;
    public string Description;
    public float Price;
    public Sprite Icon;
}

[Serializable] public class PantData
{
    public int ID;
    public string Name;
    public string Description;
    public float Price;
    public Sprite Icon;
    public Material Pant;
}

[Serializable] public class ShieldData
{
    public int ID;
    public string Name;
    public string Description;
    public float Price;
    public Sprite Icon; 
    public GameObject Shield;
}

[Serializable] public class SetData
{
    public int ID;
    public string Name;
    public string Description;
    public float Price;
    public Sprite Icon;
    //public GameObject Set;
}