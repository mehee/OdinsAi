using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Effect/Autoattack")]
public class Autoattack : InstantEffect {

	public override void Apply(GameObject target)
	{
		target.GetComponent<Health>().subtractHealthBy(Magnitude);
	}

}
