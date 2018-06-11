using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitReg : MonoBehaviour {
	private GameObject player;
	private Health healthScript;
	[SerializeField] private GameObject bloodObj;
	private Image bloodImg;
	private Color bloodCol;
	private Health health;
	private float scale; // dynamisch je nach Schaden steigern, Wert zwischen 1 und 0: CurrentHealth/MaxHealth!
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		healthScript = player.GetComponent<Health>();
		health = FindObjectOfType<Player>().GetComponent<Health>();
		bloodImg = bloodObj.GetComponent<Image>();
		bloodCol = bloodImg.color;
		bloodCol.a = 0f;
		bloodImg.color = bloodCol;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(healthScript.DmgReceived);
		scale = 1-(health.Value / health.Maximum);
		if (healthScript.DmgReceived)
		{
			fadeInBlood(scale);
		}
		if (!healthScript.DmgReceived)
		{
			fadeOutBlood();
		}
	}
	void fadeInBlood(float scaleParam)
	{	
		bloodCol.a = scaleParam;
		bloodImg.color = bloodCol;
		healthScript.DmgReceived = false;
	}
	void fadeOutBlood()
	{	
		float alphaDiff = Mathf.Abs(bloodCol.a-0f);
        if (alphaDiff>0.0001f)
        {
             bloodCol.a = Mathf.Lerp(bloodCol.a,0f,0.25f*Time.deltaTime);
             bloodImg.color = bloodCol;
        }
	}
}
