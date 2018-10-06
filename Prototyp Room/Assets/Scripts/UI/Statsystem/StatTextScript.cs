using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTextScript : MonoBehaviour {

	private static StatTextScript instance;

    public static StatTextScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatTextScript>();
            }

            return instance;
        }
    }
	[SerializeField]
	private Player player;
	[SerializeField]
	private Text characterName, level, points, armor, health, strength, intelligence;

	public void UpdateStatsText() 
	{	
		characterName.text = player.characterName;
		level.text = "Level: " + player.level;
		points.text = "Points to spend: " + player.StatPoints;
		armor.text = "Armor: " + player.stats.Armor;
		health.text = "Stamina: " + player.stats.Health;
		strength.text = "Strength: " + player.stats.Strength;
		intelligence.text = "Intelligence: " + player.stats.Intelligence;
	}


}
