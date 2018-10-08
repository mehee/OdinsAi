using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour 
{
    [HideInInspector]
    public bool rooted;

   	[SerializeField]
	private float movementSpeed;
	Rigidbody2D rigidBody;

    Collision2D collider = null;
    
    public bool hasDash;
     int availableDashes = 3;
    [SerializeField]
    float dashDuration;
    [SerializeField]
    float dashSpeed;
    float dashTimer;

    private BoxCollider2D playerCollider;
    


    public float dashCD = 5;

    [SerializeField]
    Image image = null;
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
        if(hasDash)
        image.color = new Color(image.color.r,image.color.g,image.color.b,0.0f);
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
	}

	

	public void Move(Vector2 movementVec)
	{
		rigidBody.velocity = movementVec * MovementSpeed;
	}

    public void Dash(Vector2 movementVec)
    {
        if(availableDashes > 0)
        { 
            this.StartCoroutine(substractMarker());
            dashTimer = dashDuration;
            dashDirection = movementVec;
            health.IsVulnerable= false;
            availableDashes--;
            playerCollider.enabled = false;
        }
    }

    void Update()
    {

        if(hasDash)
        {
            dashCD -= Time.deltaTime;

            if(dashCD<=0)
            {
            
                this.StartCoroutine(addMarker());
                dashCD=5;
            }

       
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
                playerCollider.enabled = true;
                health.IsVulnerable= true;
            }
        }
    }


    IEnumerator substractMarker()
	{
		image.color = new Color(image.color.r,image.color.g,image.color.b,1.0f);
		image.fillAmount -= 0.35f;
		yield return new WaitForSeconds(0.5f);
		image.color = new Color(image.color.r,image.color.g,image.color.b,0.0f);
	}
	IEnumerator addMarker()
	{
		if(image.fillAmount !=1.0f)
		{
		    image.color = new Color(image.color.r,image.color.g,image.color.b,1.0f);
			image.fillAmount += 0.35f;
			AvailableDashes++;
			yield return new WaitForSeconds(0.5f);
			image.color = new Color(image.color.r,image.color.g,image.color.b,0.0f);
		}
	}


	
}
