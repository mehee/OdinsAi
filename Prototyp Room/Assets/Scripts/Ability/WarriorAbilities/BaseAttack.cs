using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(BoxCollider2D))]
public class BaseAttack : Ability
{
	public Damage damage;
	new BoxCollider2D collider;
	
	public override void SetUp()
	{
		collider = GetComponent<BoxCollider2D>();
	}

	public override void OnActivation()
	{
		collider.enabled = true;
	}
}
