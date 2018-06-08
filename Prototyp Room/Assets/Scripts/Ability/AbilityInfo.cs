using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/** Wrapper around all information
	that an ability could need. */
public struct AbilityInfo 
{
	public string name;
	[TextArea(2, 5)]
	public string description;

	public float baseCooldown;
	public float baseCost;
	public float baseDamage;

	public float cooldownModifier;
	public float costModifier;
	public float damageModifier;

	public float strengthScaling;
	public float intelligenceScaling;

	public int startupFrames;
	public int activeFrames;
	public int endingFrames;

	public Sprite icon;
	public AudioClip sound;
}
