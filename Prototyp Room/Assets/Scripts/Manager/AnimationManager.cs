using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	private Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator> ();
	}
	
	public void Walk(Vector2 vector2)
	{
		
		animator.SetBool("iswalking",true);
        animator.SetBool("isAttacking", false);

        animator.SetFloat("input_x", vector2.x);
		animator.SetFloat("input_y", vector2.y);
	}
	public void Stay(Vector2 vector2)
	{
		animator.SetBool("iswalking",false);
        animator.SetBool("isAttacking", false);

        animator.SetFloat("input_x", vector2.x);
		animator.SetFloat("input_y", vector2.y);
	}

    public void Attack(Vector2 vector2)
    {
        animator.SetBool("isAttacking", true);
        animator.SetBool("iswalking", false);

        animator.SetFloat("input_x", vector2.x);
        animator.SetFloat("input_y", vector2.y);
    }
	public void Dash(Vector2 vector2)
	{
		
        animator.SetFloat("input_x", vector2.x);
        animator.SetFloat("input_y", vector2.y);
		animator.Play("Dashing");
	}

    public void Charge(Vector2 vector2)
    {
        animator.SetBool("isCharging", true);
        


        animator.SetFloat("input_x", vector2.x);
        animator.SetFloat("input_y", vector2.y);
    }
}
