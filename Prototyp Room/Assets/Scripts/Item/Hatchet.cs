using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The axe thrown be the warriors
	axe throw ability. Make sure to
	disable the collider on the prefab
	by default so it does not trigger
	when spawned. */
public class Hatchet : MonoBehaviour 
{
	[SerializeField]
	Bleed bleed;
    [SerializeField]
    float maxDistanceFromOwner;
    public float flightDistance;

    [HideInInspector]
    public ThrowHatchet owner;
    new Collider2D collider;
    Vector3 lastPosition;
    Vector2 velocity = Vector2.zero;


	float damage;
	float distanceFlown;

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
        GetComponent<Collider2D>().enabled = false;
        lastPosition = transform.position;
	}

	void Update()
	{
		if(Velocity != Vector2.zero)
        {
            transform.position += (Vector3)(Velocity * Time.deltaTime);
            distanceFlown += Mathf.Abs((transform.position - lastPosition).magnitude);
            if(distanceFlown > flightDistance)
            {
                Velocity = Vector2.zero;
            }
            lastPosition = transform.position;
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
            Debug.Log(Velocity);
        }
	}

    /** The player 'picks up' the hatchet. */
    void RecoverHatchet()
    {
        owner.currentAmountHatchets++;
        Destroy(this.gameObject);
    }
}
