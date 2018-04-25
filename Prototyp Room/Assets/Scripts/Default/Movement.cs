using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField]
	private float movementSpeed;
	Rigidbody2D rigiBbody;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
            movementSpeed = value;
        }
    }

    void Start () 
	{
		rigiBbody = GetComponent<Rigidbody2D> ();
		
	}

	public void Move(Vector2 movementVec)
	{
		if(rigiBbody!= null)
		rigiBbody.velocity = movementVec * MovementSpeed;
	
	}
	
}
