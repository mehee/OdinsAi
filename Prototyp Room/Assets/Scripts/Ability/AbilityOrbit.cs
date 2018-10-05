using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** Use this struct to define an orbit around
		a character on which the abilities hitbox
		will be positioned. This way you can have
		the hitbox correctly rotate around characters
		that are taller than they are broad. */
	[System.Serializable]
	public struct AbilityOrbit
	{
		public bool orbiting;
		public Vector2 orbitRadii;
	}
}
