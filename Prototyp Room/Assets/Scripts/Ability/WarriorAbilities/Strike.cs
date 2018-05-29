using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : Ability 
{
	[SerializeField][Tooltip("Determines how much stronger" + 
		"the ability gets per bloodlust interval.")]
	private float bonusDamageRatio;
	[SerializeField][Tooltip("Determines how much bloodlust" + 
		"is necessary to gain an extra tier of bonus damage.")]
	private int bloodlustInterval;

	// For every {bloodlustInterval} units of bloodlust,
	// the Damage is increased by {bonusDamageRation}.   
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag != "Enemy")
			return;
		var health = other.gameObject.GetComponent<Health>();
		var bloodlust = transform.root.GetComponent<Bloodlust>();
		float totalDamage = Mathf.Floor(bloodlust.Value / bloodlustInterval);
		totalDamage *= bonusDamageRatio;
		totalDamage = Damage + (Damage * totalDamage);
		health.Reduce(totalDamage);
	}
}
