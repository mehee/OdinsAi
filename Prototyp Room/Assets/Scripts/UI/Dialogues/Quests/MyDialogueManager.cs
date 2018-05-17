using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogueManager : MonoBehaviour {

	//GameObjekt of Text displayed if entering Trigger
	public GameObject guiDialogText;
	public GameObject canvasQuestUi;
	//show Text on Canvas
	public Text npcNameText;
	public Text questText;

	private Queue<string> sentences;
	private GameObject player;
	private bool playerIsOnTrigger = false;

	void Start () 
	{
		sentences = new Queue<string>();
		//deaktivate Text and UI
		guiDialogText.SetActive(false);
		canvasQuestUi.SetActive(false);
	}

	void Update()
	{
		if(playerIsOnTrigger && guiDialogText.activeInHierarchy == true && Input.GetButtonDown("Use"))
		{
			DisplayNextSentence();
			canvasQuestUi.SetActive(true);
		}

	}
	
	//fill Queue with all dialogues
	public void StartDialog(MyDialogue dialogue)
	{
		//Debug.Log("Starting Conversation with " + dialogue.npcName);
		
		npcNameText.text = dialogue.npcName;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialog();
			return;
		}

		string sentence = sentences.Dequeue();
		
		//Coroutines just for writing the Text
		// has to stop the others, so non will overlap
		StopAllCoroutines();
		StartCoroutine(WriteQuestText(sentence));
	}

	void EndDialog()
	{
		Debug.Log("End Dialog");
	}

	//slowly write the Questtext
	IEnumerator WriteQuestText(string sentence)
	{
		questText.text = "";
		//loop through all chars in sentence and put in char[]
		foreach (char letter in sentence.ToCharArray())
		{
			questText.text += letter;
			yield return null;
		}
	}

	//Trigger Managing
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiDialogText.SetActive(true);			
			playerIsOnTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiDialogText.SetActive(false);
			canvasQuestUi.SetActive(false);
			playerIsOnTrigger = false;
		}
	}
}
