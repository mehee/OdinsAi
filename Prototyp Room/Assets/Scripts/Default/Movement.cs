using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
   	[SerializeField]
	private float movementSpeed;
	Rigidbody2D rigidBody;
    
    int availableDashes = 3;
    CombatMarker combatMarker;
   
    [SerializeField]
    float dashDuration;
    [SerializeField]
    float dashSpeed;
    float dashTimer;
    private float timer;
    Vector2 dashDirection;
     Vector2 direction;

    Health health;

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

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public int AvailableDashes
    {
        get
        {
            return availableDashes;
        }

        set
        {
            availableDashes = value;
        }
    }

    void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health> ();
        combatMarker = GameObject.FindObjectOfType(typeof(CombatMarker)) as CombatMarker;
	}

	public void Move(Vector2 movementVec)
	{
		    rigidBody.velocity = movementVec * MovementSpeed;
	}

    public void Dash(Vector2 movementVec)
    {
        if(availableDashes>0)
        { 
        dashTimer = dashDuration;
        dashDirection = movementVec;
        health.IsVulnerable= false;
        availableDashes--;
        }
    }

    void OnCollisionEnter2D()
    {
     dashTimer=0;  
    }
    
    void Update()
    {

       // Debug.Log(  combatMarker = GetComponentInChildren<CombatMarker>());
        if(dashTimer > 0)
        {
            rigidBody.velocity = dashSpeed * dashDirection;
            dashTimer -= Time.deltaTime;
            if(dashTimer < 0)
                dashTimer = 0;
        }

        if(dashTimer == 0)
        {
            rigidBody.velocity = Vector2.zero;
            health.IsVulnerable= true;
        }
    }
	
}
