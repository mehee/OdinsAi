using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class Fireball : PoolObject 
{
	public string targetTag = "Enemy";
	public Damage damage;
	public float speed;
	[HideInInspector]
	public Stats stats;
	[HideInInspector]
	public Vector2 direction;

	AbilitySystem.Cooldown lifeTime;

	void Awake()
	{
		lifeTime = GetComponent<AbilitySystem.Cooldown>();
	}

	void LateUpdate()
	{
		if(lifeTime.IsActive == false)
		{
			owner.Retrieve(this);
		}

		transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == targetTag)
		{
			var health = other.gameObject.GetComponent<Health>();
			damage.InflictToTarget(stats, health);
		}
	}

	void OnEnable()
	{
		lifeTime.StartTimer();
	}
}
