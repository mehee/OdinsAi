using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType {Head, Chest, Legs, Boots, Ring, Trinket, Runestone, MainHand, Offhand, TwoHand}
//public enum WeaponType {MainHand, Offhand, TwoHand}

public static class ArmorTypClass
{
    private static Dictionary<ArmorType, string> armorName = new Dictionary<ArmorType, string>()
    {
        {ArmorType.Head, "Head"},
        {ArmorType.Chest, "Chest"},
        {ArmorType.Legs, "Legs"},
        {ArmorType.Boots, "Boots"},
        {ArmorType.Ring, "Ring"},
        {ArmorType.Trinket, "Trinket"},
        {ArmorType.Runestone, "Runestone"},
        {ArmorType.MainHand, "Mainhand"},
        {ArmorType.Offhand, "Offhand"},
        {ArmorType.TwoHand, "Twohand"}
    };

    public static Dictionary<ArmorType, string> MyArmorType
	{
		get{return armorName;}
	}

/*
    private static Dictionary<WeaponType, string> weaponName = new Dictionary<WeaponType, string>()
    {
        {WeaponType.MainHand, "Mainhand"},
        {WeaponType.Offhand, "Offhand"},
        {WeaponType.TwoHand, "Twohand"}
    };

    public static Dictionary<WeaponType, string> MyWeaponType
	{
		get{return weaponName;}
	}
 */
}
