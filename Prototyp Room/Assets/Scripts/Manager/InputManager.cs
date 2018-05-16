using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{

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
			animator.Stay(movementVec);

		if(Input.GetButtonDown("Jump"))
			movement.Dash(movementVec);

		if(movement.DashTimer == 0)
			movement.Move(movementVec);
		
		if(Input.GetButtonDown("Ability1"))
			GetComponentInChildren<Maul>().Activate();

	}
}
