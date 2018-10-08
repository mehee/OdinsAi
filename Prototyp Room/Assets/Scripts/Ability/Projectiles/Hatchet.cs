using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

/** The axe thrown be the warriors
	axe throw ability. Make sure to
	disable the collider on the prefab
	by default so it does not trigger
	when spawned. */
public class Hatchet : PoolObject
{
    public float speed;
	[SerializeField] 
    Bleed bleed;

    [HideInInspector] 
    public Damage damage;
    [HideInInspector]
    public Stats stats;
    
    Vector2 direction;
    Vector2 velocity;
    Timer lifeTime;

    public Vector2 Direction
    {
        set
        {
            direction = value;
            velocity = direction * speed;
        }
    }

    void OnEnable()
    {
        lifeTime.StartTimer();
    }

    void Awake()
	{
        lifeTime = GetComponent<Timer>();
	}

	void Update()
	{
        if(!lifeTime.IsActive)
		{
			owner.Retrieve(this);
		}

        transform.position += (Vector3)(velocity * Time.deltaTime);
        float distanceFromOwner = (transform.position - owner.transform.position).magnitude;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(Velocity != Vector2.zero)
		{
            if(other.tag == "Enemy")
            {
                bleed.Attach(other.transform);
                other.GetComponent<Health>().Reduce(damage);
            }
            else if(!(other.tag == "Enemy" || other.tag == "Player"))
            {
                Velocity = Vector2.zero;
            }
		}
        else if(Velocity == Vector2.zero && other.tag == "Player")
        {
            bleed.Attach(other.transform);
            var health = other.GetComponent<Health>();
            damage.InflictToTarget(stats, health);
            owner.Retrieve(this);
        }
	}
}
