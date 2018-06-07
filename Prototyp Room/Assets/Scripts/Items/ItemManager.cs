using UnityEngine;
using System.Collections;
using System.Collections.Generic; 	// for lists
using System.Xml;					//basic xml attributes
using System.Xml.Serialization; 	// access to xml serializer
using System.IO;					// file management, also for other filetyps like json

public class ItemManager : MonoBehaviour {

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

//variables that populate our ItemDatabase
[System.Serializable]
public class ItemEntry
{
	public string itemName;
	public int itemStrength;
	public int itemIntelligent;
	public int itemVitality;
	public ItemType itemType;
}

//ItemDatabase for the XML file
[System.Serializable]
public class ItemDatabase
{
	public List<ItemEntry> items = new List<ItemEntry>();
}