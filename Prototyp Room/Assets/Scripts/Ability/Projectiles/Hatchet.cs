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
	[SerializeField] Bleed bleed;

    [HideInInspector] 
    public new Collider2D collider;
    [HideInInspector] 
    public Damage damage;
    [HideInInspector]
    public Stats stats;
    
    Vector2 direction;
    Vector2 velocity;
    SpriteRenderer spriteRenderer;
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
        collider = GetComponent<Collider2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeTime = GetComponent<Timer>();
	}

	void Update()
	{
        transform.position += (Vector3)(velocity * Time.deltaTime);
        float distanceFromOwner = (transform.position - owner.transform.position).magnitude;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.tag == "Enemy" && other is BoxCollider2D)
        {
            bleed.Attach(other.transform);
            var health = other.GetComponent<Health>();
            damage.InflictToTarget(stats, health);
            owner.Retrieve(this);
        }
	}
}
