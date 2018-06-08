using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
	AbilityInfo info;

	// Rotation and direction of the ability
	// are clamped to the eight cardinal directions
	Quaternion rotation;
	Vector2 direction;

	void AlignWithMouse()
	{
		Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.x = Mathf.Round(rawDirection.x);
		direction.y = Mathf.Round(rawDirection.y);
	}
}
