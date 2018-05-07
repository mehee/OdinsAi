using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VileStrike : Ability
{
	Transform player;

	protected override void Awake()
	{
		base.Awake();
		collider.enabled = true;
		player = FindObjectOfType<Player>().transform;
	}

	public override void Activate()
    {
		base.Activate();
		Vector3 difference =  player.position - transform.position;
		float rotation = Mathf.Atan2(difference.y, difference.x) 
			* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != "Player")
			return;
		other.gameObject.GetComponent<Health>().Reduce(Damage);
		Debug.Log(other.gameObject.name);
    }
}
