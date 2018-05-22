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

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag != "Enemy")
			return;
		var health = other.gameObject.GetComponent<Health>();
		
	}
}
