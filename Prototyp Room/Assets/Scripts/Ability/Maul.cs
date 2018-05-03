using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Basic attack for the warrior. */
public sealed class Maul : Ability
{
    public override void Activate(float resource)
    {
		base.Activate(resource);
		Vector3 difference = Camera.main.ScreenToWorldPoint(
			Input.mousePosition) - transform.position;
		float rotation = Mathf.Atan2(difference.y, difference.x) 
			* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != "Enemy")
			return;
		other.gameObject.GetComponent<Health>().Reduce(Damage);
		Debug.Log(other.gameObject.name);
    }
}
