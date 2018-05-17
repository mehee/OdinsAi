using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyDialogue
{

	public string npcName;

	[TextArea(3,10)] // minimum lines, maximum lines
	public string[] sentences;

}
