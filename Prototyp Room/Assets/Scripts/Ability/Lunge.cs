﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : Ability
{
	bool moving = false;
	Vector2 targetPostition;
	Vector2 direction;
	Transform parent;

	[SerializeField]
	float speed;

	public override void Activate(float resource)
	{
		base.Activate(resource);
		Vector2 mousePosition = 
			Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPostition = mousePosition;
		direction = mousePosition - (Vector2)parent.position;
		direction.Normalize();
		moving = true;
		Debug.Log(moving);
	}

    protected override void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Enemy")
		{
        	other.gameObject.GetComponent<Health>().Reduce(Damage);
		}
    }

	protected override void Update()
	{
		base.Update();
		if(moving)
		{
			Vector2 nextPosition;
			nextPosition = direction * speed * Time.deltaTime;
			parent.GetComponent<Rigidbody2D>().MovePosition(nextPosition);
		}

		if((Vector2)transform.position == targetPostition)
		{
			collider.enabled = true;
		}

		if(collider.enabled == true)
		{
			parent.GetComponent<Movement>().enabled = false;
		}
		else
		{
			parent.GetComponent<Movement>().enabled = true;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		parent = transform.parent;
	}
}