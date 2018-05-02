using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private Movement movement;
	private AnimationManager animator;


	// Use this for initialization
	void Start () 
	{
	movement = GetComponent<Movement> ();	
	animator = GetComponent<AnimationManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 movementVec = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		movementVec = movementVec.normalized;
		
		if(movementVec!= Vector2.zero)
		{
			animator.Walk(movementVec);
		}
		else
		animator.Stay();

		movement.Move(movementVec);
		//check if input is there


	if(Input.GetButtonDown("1"))
	{
		GetComponent<AbilitySet>().UseAbilityAtIndex(0);
	}

	}
}
