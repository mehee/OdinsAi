﻿using UnityEngine;
using AbilitySystem;

/** Explodes after a short while. */
public class SpellBomb : PoolObject 
{
	[HideInInspector]
	public Stats stats;

	[HideInInspector]
	public Damage damage;
	
	public Color startingColor;
	public Color finalColor;

	/** How many seconds of the total
		life time the collider will be
		active. */
	[SerializeField]
	float timeBeforeExplosion = 1.5f;
	[SerializeField]
	int hitboxLiveFrames = 2;


	CircleCollider2D hitbox;
	SpriteRenderer spriteRenderer;
	float timeAlive;
	float frameCount;

	
	void Awake () 
	{
		hitbox = GetComponent<CircleCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		Reset();
	}

	void OnEnable()
	{
		Reset();
	}
	
	void Update () 
	{
		timeAlive += Time.deltaTime;
		float quotient = timeAlive / timeBeforeExplosion;
		if(quotient < 1f)
		{
			spriteRenderer.color = Color.Lerp(spriteRenderer.color,
				finalColor, quotient);
		}
		else
		{
			if(!hitbox.enabled)
				hitbox.enabled = true;
			frameCount++;
			if(frameCount == hitboxLiveFrames)
				owner.Retrieve(this);
		}	
	}

	void Reset()
	{
		spriteRenderer.color = startingColor;
		timeAlive = 0;
		frameCount = 0;
		hitbox.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other is BoxCollider2D && other.gameObject.tag == "Player")
		{
			var health = other.GetComponent<Health>();
			damage.InflictToTarget(stats, health);
		}
	}
}
