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
	float damage;
	float flightDistance;

    public Vector2 Velocity
    {
        get
        {
            return velocity;
        }

        set
        {
            velocity = value;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public float FlightDistance
    {
        get
        {
            return flightDistance;
        }

        set
        {
            flightDistance = value;
        }
    }

    void Awake()
	{
		velocity = Vector2.zero;
	}

	void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(velocity != Vector2.zero)
		{
			bleed.Attach(other.transform);
			other.GetComponent<Health>().Reduce(damage);
		}
	}
}
