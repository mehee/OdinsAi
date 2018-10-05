using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The axe thrown be the warriors
	axe throw ability. Make sure to
	disable the collider on the prefab
	by default so it does not trigger
	when spawned. */
public class Hatchet : PoolObject
{
	[SerializeField] Bleed bleed;
    [SerializeField] float maxDistanceFromOwner;
    public float flightDistance;

    [HideInInspector] public Vector3 currentPosition;
    Vector2 velocity = Vector2.zero;

	float damage;
	float distanceFlown;

    [HideInInspector] public new Collider2D collider;
    [HideInInspector] public SpriteRenderer spriteRenderer;

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

    public float DistanceFlown
    {
        get
        {
            return distanceFlown;
        }

        set
        {
            distanceFlown = value;
        }
    }

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

    void Awake()
	{
        collider = GetComponent<Collider2D>(); 
        collider.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if(Velocity != Vector2.zero)
        {
            transform.position += (Vector3)(Velocity * Time.deltaTime);
            distanceFlown += Mathf.Abs((transform.position - currentPosition).magnitude);
            if(distanceFlown > flightDistance)
            {
                Velocity = Vector2.zero;
            }
            currentPosition = transform.position;
        }

        float distanceFromOwner = (transform.position - owner.transform.position).magnitude;
        if(distanceFromOwner > maxDistanceFromOwner)
            RecoverHatchet();
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
            RecoverHatchet();
        }
	}

    /** The player 'picks up' the hatchet. */
    void RecoverHatchet()
    {
        owner.Retrieve(this);
    }
}
