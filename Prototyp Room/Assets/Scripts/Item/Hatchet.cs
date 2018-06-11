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
    public float flightDistance;
    Rigidbody2D rb;
    new Collider2D collider;

    Vector3 lastPosition = Vector2.zero;

	[SerializeField]
	Bleed bleed;

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

    void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.zero;
        collider = GetComponent<Collider2D>(); 
        GetComponent<Collider2D>().enabled = false;
	}

	void Update()
	{
		if(rb.velocity != Vector2.zero)
        {
            distanceFlown += Mathf.Abs((transform.position - lastPosition).magnitude);
            if(distanceFlown > flightDistance)
            {
                rb.velocity = Vector2.zero;
            }
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(rb.velocity != Vector2.zero)
		{
            if(other.tag == "Enemy")
            {
                bleed.Attach(other.transform);
                other.GetComponent<Health>().Reduce(damage);
            }
            else if(!(other.tag == "Enemy" || other.tag == "Player"))
            {
                rb.velocity = Vector2.zero;
            }
		}
        else if(rb.velocity == Vector2.zero && other.tag == "Player")
        {
            collider.enabled = false;
            distanceFlown = 0;
            transform.position = transform.parent.position;
        }
	}
}
