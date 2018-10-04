using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSButton : MonoBehaviour {

	// Use this for initialization
	Button button;
	protected Player player;
	
	public int statNumber;

    void Start () 
	{
		player = GetComponentInParent<Player>();
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
		button.gameObject.SetActive(false);

	}
	
	// Update is called once per frame

	public void Show()
	{
		button.gameObject.SetActive(true);
	}

	void Hide()
	{
		button.gameObject.SetActive(false);
	}

	void OnClick()
	{
		player.PointsToSpend--;
		switch(statNumber)
		{
			case 0: player.stats.Health++;
					break;
			case 1: player.stats.Armor++;
					break;
			case 2: player.stats.Strength++;
					break;
			case 3: player.stats.Intelligence++;
					break;
		}
	}

	
	void Update()
	{
		if(player.PointsToSpend==0)
		Hide();
	}
}
