using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

	[SerializeField]
	private float movementSpeed;
	Rigidbody2D rigidBody;

    [SerializeField]
    float dashDuration;
    [SerializeField]
    float dashSpeed;
    float dashTimer;
    Vector2 dashDirection;


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

    public float DashTimer
    {
        get
        {
            return dashTimer;
        }
    }

    void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 movementVec)
	{
		    rigidBody.velocity = movementVec * MovementSpeed;
	}

    public void Dash(Vector2 movementVec)
    {
        dashTimer = dashDuration;
        dashDirection = movementVec;
    }

    void Update()
    {
        if(dashTimer > 0)
        {
            rigidBody.velocity = dashSpeed * dashDirection;
            dashTimer -= Time.deltaTime;
            if(dashTimer < 0)
                dashTimer = 0;
        }

        if(dashTimer == 0)
            rigidBody.velocity = Vector2.zero;
    }
	
}
