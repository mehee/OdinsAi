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
		animator.SetFloat("input_x", vector2.x);
		animator.SetFloat("input_y", vector2.y);
	}
	public void Stay()
	{
		animator.SetBool("iswalking",false);
	}
}
