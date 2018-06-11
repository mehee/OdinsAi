using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

	public GameObject chest;
	public Enemy enemy;

	void Loot()
	{
		Debug.Log(enemy.IsLootable);
		if(enemy.IsLootable)
		{
			Debug.Log("Lootchest spawned");
			var newChest = Instantiate(chest,enemy.transform.position,Quaternion.identity);
		}
	}	


}
