using UnityEngine;
using System.Collections;
using System.Collections.Generic; 	// for lists
using System.Xml;					//basic xml attributes
using System.Xml.Serialization; 	// access to xml serializer
using System.IO;					// file management, also for other filetyps like json

public class ItemManager : MonoBehaviour 
{

	public static ItemManager im;

	void Awake()
	{
		im = this;
	}

	//list of Items
	public ItemDatabase itemDatabase;
}

//enum for which Type/Bodypart of Item
public enum ItemType { Head, Chest, Legs, MainHand, OffHand }
public enum ItemQuality { Common, Uncommon, Rare, Epic, Legendary }

//variables that populate our ItemDatabase
[System.Serializable]
public class ItemEntry
{
	public string name;
	public ItemQuality quality;
	public ItemType type;
	public int strength;
	public int intelligence;
	public int vitality;
}

//ItemDatabase for the XML file
[System.Serializable]
public class ItemDatabase
{
	public List<ItemEntry> items = new List<ItemEntry>();
}