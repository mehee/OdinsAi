using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private new string name;
	[SerializeField]
	private	uint currentLvl;	

	private Player player;


	//Use this for testing only
 	 private Health health;
	 private Experience experience;

	// Use this for initialization
	void Awake () 
	{
		player = new Player(name,currentLvl);


		//Use this for testing only
		experience = GetComponent<Experience> ();
		health = GetComponent< Health> ();
		
	}

	public  Player getPlayer()
	{
		return  player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Use this for testing only
	if(Input.GetKeyDown(KeyCode.E))
	experience.addExp(50);

	if(Input.GetKeyDown(KeyCode.H))
	health.subtractHealthBy(50);
	
	
	}
}
