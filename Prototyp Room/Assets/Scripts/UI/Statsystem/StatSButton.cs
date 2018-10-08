using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatSButton : MonoBehaviour {

	private enum StatsNumber {stamina, strength, intelligence}

	[SerializeField]
	private StatsNumber wichStat;
	// Use this for initialization
	//public int statNumber;

	[SerializeField]
	private Player player;
	private Button button;

    void Start () 
	{
		button = this.GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(player.StatPoints == 0)
		{
			Hide();
		}
		else
		{
			Show();
		}
	}

	public void Show()
	{
		button.GetComponent<CanvasGroup>().alpha =  1.0f ;
		button.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	void Hide()
	{
		button.GetComponent<CanvasGroup>().alpha = 0.0f;
		button.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	void OnClick()
	{
		player.StatPoints--;
		switch(wichStat)
		{
			case StatsNumber.stamina: player.stats.Health++ ;
					break;
			case StatsNumber.strength: player.stats.Strength++;
					break;
			case StatsNumber.intelligence: player.stats.Intelligence++;
					break;
		}
		player.hpValueReset();
		StatTextScript.MyInstance.UpdateStatsText();
	}

	
}
