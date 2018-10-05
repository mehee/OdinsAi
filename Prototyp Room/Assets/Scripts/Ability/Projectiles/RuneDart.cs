using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(BoxCollider2D), typeof(AbilitySystem.Timer))]
public class RuneDart : MonoBehaviour
{
	public Damage damage;
	public float speed;
	public float spreadAngle = 30f;

	[HideInInspector]
	public Vector2 direction;
	[HideInInspector]
	public Stats stats;
	[HideInInspector]
	public Vector2 velocity;

	Timer cooldown;

	void Start()
	{
		cooldown = GetComponent<Timer>();
		cooldown.StartTimer();
		CalculateVelocity();
		transform.up = velocity.normalized;
	}

	void Update()
	{
		if(!cooldown.IsActive)
			Destroy(gameObject);
		transform.position += (Vector3)velocity * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other is BoxCollider2D && other.gameObject.tag == "Enemy")
		{
			var health = other.gameObject.GetComponent<Health>();
			damage.InflictToTarget(stats, health);
		}
	}

	void CalculateVelocity()
	{
		float angle = Mathf.Atan2(direction.x, direction.y);
		angle *= Mathf.Rad2Deg;
		angle += Random.Range(-spreadAngle, spreadAngle);
		angle *= Mathf.Deg2Rad;
		var newDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
		velocity = newDirection * speed;
	}
}
