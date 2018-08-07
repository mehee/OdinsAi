using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour 
{
	public MyDialogue dialogue;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			FindObjectOfType<MyDialogueManager>().StartDialog(dialogue);
		}
	}

}
