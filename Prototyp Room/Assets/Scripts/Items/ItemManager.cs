using UnityEngine;
using System.Collections.Generic; 	// for lists
using System.Xml.Serialization; 	// access to xml serializer
using System.IO;					// file management, also for other filetyps like json

public class ItemManager : MonoBehaviour 
{
	public static ItemManager im;

	void Awake()
	{
		im = this;
		SaveItems();
		//LoadItems();
	}
	

	//list of Items
	public ItemDatabase itemDatabase;

	//save function
	public void SaveItems()
	{
		//open new XML file
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		//Filestream (ones and zeros); dataPath for items,Monster etc. persistentDataPath for Savegames
		FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/item_data.xml",FileMode.Create); //override old XML
		//fill XML
		serializer.Serialize(stream,itemDatabase);
		stream.Close();
	}

	//load function for in XML added Items
	public void LoadItems()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/item_data.xml",FileMode.Open);//open existing XML
		itemDatabase = serializer.Deserialize(stream) as ItemDatabase; 
		stream.Close();
	}
}

//enum for which Type/Bodypart of Item
public enum ItemType { Head, Chest, Legs, Boots, Ring, Trinket, MainHand, OffHand }
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
	//Change how XML calles it for having more Lists etc
	[XmlArray("CombatEquipment")]
	public List<ItemEntry> items = new List<ItemEntry>();
}