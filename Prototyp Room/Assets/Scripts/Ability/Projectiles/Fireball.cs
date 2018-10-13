using UnityEngine;
using AbilitySystem;

/** Fireball flying in a straight line.
	Passes through enemies and damages
	all it hits. */
public class Fireball : PoolObject 
{
	public string targetTag = "Enemy";
	public float speed;

	[HideInInspector]
	public Stats stats;

	[HideInInspector]
	public Vector2 direction;

	[HideInInspector]
	public Damage damage;

	Timer lifeTime;

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

		transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == targetTag && other is BoxCollider2D)
		{
			var health = other.gameObject.GetComponent<Health>();
			damage.InflictToTarget(stats, health);
		}
	}

	void OnEnable()
	{
		lifeTime.StartTimer();
	}
}
