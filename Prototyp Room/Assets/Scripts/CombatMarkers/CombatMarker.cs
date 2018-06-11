using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMarker : MonoBehaviour {
	[SerializeField] private GameObject combatMarkerEffect;
	[SerializeField] private GameObject player;
	// Use this for initialization
	void Start () {
		combatMarkerEffect.transform.position = player.transform.position;
		combatMarkerEffect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Ability1"))
		{
			combatMarkerEffect.SetActive(true);
			combatMarkerEffect.transform.position = player.transform.position;
		}
	}
}
