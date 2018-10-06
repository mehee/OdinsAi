using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;


public class ButtonScript : Ability, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

	// Use this for initialization
	Button button;
	Image image;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int skillNumber;

	public int skillAvalaibleAt;
	public Ability ability;
	
    void Start () 
	{
		button = GetComponent<Button>();
		Debug.Log(button);
		image = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();
		Deactive();
	}
	
	// Update is called once per frame

	void Active()
	{

		Debug.Log(skillAvalaibleAt==player.level);
		if(skillAvalaibleAt==player.level)
		{
		button.enabled=true;
		image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
		}
	}

	void Deactive()
	{
		button.enabled=false;
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2f);
		
	}

	void Update()
	{
		if(player.SpellPoints==0)
		{
		Deactive();
		}
		else
		this.Active();

	}

	//ClickHandler
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left)
		{
			if(player.SpellPoints>0)
			--player.SpellPoints;
			abilityKit.SwapSkill(ability,skillNumber);
		}
	}

	// --- Tooltips
	public void OnPointerEnter(PointerEventData eventData)
	{
		if(ability != null)
		{
			UIManager.MyInstance.ShowTooltip(transform.position, ability);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}
}