using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Holds all abilites a character
	has at its disposal. */
public class AbilitySet : MonoBehaviour 
{
	float lastActivationTime;

	[SerializeField]
	float globalCooldown = 0.15f;

	public List<Ability> abilities;

	void Awake()
	{
		lastActivationTime = -globalCooldown;
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
