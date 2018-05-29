using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The axe thrown be the warriors
	axe throw ability. Make sure to
	disable the collider on the prefab
	by default so it does not trigger
	when spawned. */
public class ThrowingAxe : MonoBehaviour 
{
	[SerializeField]
	Bleed bleed;
	Vector2 velocity;

	void Awake()
	{
		velocity = Vector2.zero;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(velocity != Vector2.zero)
		{

		}

		if(other.gameObject.tag == "Player")
		{
			var axeThrow = other.gameObject.GetComponentInChildren<AxeThrow>();
			enabled = false;
		}
	}
}
