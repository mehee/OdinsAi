using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

public Transform target;
private Transform player;
private Camera camera;
	// Use this for initialization
	void Start () 
	{
		//prüfen ob es ein Objekt in Hierarchy gibt, welches den tag Player trägt
		// dieses dann als target zuweisen
		camera = GetComponent<Camera>();
		target = player;
	}
	
	// Update is called once per frame
	void Update () 
	{
	camera.orthographicSize = (Screen.height/100f)*1.5f;	

	if(target)
	{
		transform.position = Vector3.Lerp(transform.position,target.position,0.1f) + new Vector3(0,0,-10);
	}
	
	}

	void setTarget(Transform p)
	{
		if(p.gameObject.tag == "Player")
			this.player = p;
	}
}
