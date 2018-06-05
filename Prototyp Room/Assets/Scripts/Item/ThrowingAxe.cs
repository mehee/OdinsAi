using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The axe thrown be the warriors
	'throw' ability. Make sure to
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
		if(velocity == Vector2.zero)
		{
			if(other.tag == "Player")
			{
				transform.position = transform.parent.position;
				transform.parent.GetComponent<AxeThrow>().currentAmountAxes++;
				enabled = false;
			}
			return;
		}

		if(other.tag == "Enemy")
		{
			bleed.Attach(other.transform);
		}

		if(other.tag != "Enemy" && other.tag != "Player")
		{
			velocity = Vector2.zero;			
		}
	}
}
