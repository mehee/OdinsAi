using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox 
{
	Vector2 position;
	Vector2 rotation;
	Vector2 scale = Vector2.one;

	int rayCastGranularity;

	Hitbox(int rayCastGranularity)
	{
		this.rayCastGranularity = rayCastGranularity;
	}


}
