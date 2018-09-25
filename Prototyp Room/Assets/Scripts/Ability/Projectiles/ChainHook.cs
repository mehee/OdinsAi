using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(CircleCollider2D))]
public class ChainHook : MonoBehaviour 
{
	AbilitySystem.Cooldown lifeTime;
	Transform hookedEnemy;

	public float flightSpeed = 10;
	[HideInInspector] public HookThrow owner;
	[HideInInspector] public Vector2 direction;
	
	void Start () 
	{
		lifeTime = GetComponent<AbilitySystem.Cooldown>();		
	}
	
	void Update () 
	{
		if(!hookedEnemy && !lifeTime.IsActive)
		{
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			if(!hookedEnemy)
			{
				hookedEnemy = other.transform;
			}
		}
	}

	void ReleaseEnemy()
	{
		hookedEnemy = null;
	}
}
