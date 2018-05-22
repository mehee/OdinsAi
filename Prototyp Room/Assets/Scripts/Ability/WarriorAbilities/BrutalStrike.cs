using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutalStrike : Ability
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != "Enemy")
			return;
		other.gameObject.GetComponent<Health>().Reduce(Damage);
		Debug.Log(other.gameObject.name);
    }

	protected override void Update()
	{
		base.Update();
	}
}
