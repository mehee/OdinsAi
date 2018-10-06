using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;

public class ButtonScript : MonoBehaviour 
{

	// Use this for initialization
	Button button;
	Image image;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int skillNumber;
	public Ability ability;
    void Start () 
	{
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();
		button.onClick.AddListener(OnClick);

	}
	
	// Update is called once per frame

	void Active()
	{
		button.enabled=true;
		image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
	}

	void Deactive()
	{
		button.enabled=false;
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
		
	}

	void OnClick()
	{
		player.SpellPoints--;
		abilityKit.SwapSkill(ability,skillNumber);
	}
	void Update()
	{
		if(player.SpellPoints==0)
		{}
	//	Deactive();
	}

}