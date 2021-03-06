﻿using System.Collections;
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
       // animator.SetBool("isCharging", false);

        animator.SetFloat("input_x", vector2.x);
		animator.SetFloat("input_y", vector2.y);
	}
	public void Stay(Vector2 vector2)
	{
		animator.SetBool("iswalking",false);
        animator.SetBool("isAttacking", false);
        //animator.SetBool("isCharging", false);

        animator.SetFloat("input_x", vector2.x);
		animator.SetFloat("input_y", vector2.y);
	}

    public void Attack(Vector2 vector2)
    {
        animator.SetBool("isAttacking", true);
        animator.SetBool("iswalking", false);
        //animator.SetBool("isCharging", false);

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
        animator.SetBool("iswalking", false);
        animator.SetBool("isAttacking", false);

        animator.SetFloat("input_x", vector2.x);
        animator.SetFloat("input_y", vector2.y);
    }

    public void setChargeFalse()
    {
        animator.SetBool("isCharging", false);
    }

    public void setAwakeingTrue()
    {
        animator.SetBool("isAwakeing", true);
    }
    public void setAwakeingFalse()
    {
        animator.SetBool("isAwakeing", false);
    }
}
