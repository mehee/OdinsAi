using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VileStrike : Ability
{
	Transform player;

	protected override void Awake()
	{
		base.Awake();
		player = FindObjectOfType<Player>().transform;
	}

	public override void Activate(float resource)
    {
		base.Activate(resource);
		Vector3 difference =  player.position - transform.position;
		float rotation = Mathf.Atan2(difference.y, difference.x) 
			* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != "Enemy")
			return;
		other.gameObject.GetComponent<Health>().Reduce(Damage);
		Debug.Log(other.gameObject.name);
    }
    
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(255f, 0f, 0f, 50f);
		BoxCollider2D bc = GetComponent<BoxCollider2D>();
		Gizmos.DrawCube(bc.offset, bc.bounds.extents * 2);
	}
}
