using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	Button button;
	Image image;
	protected Player player;

    void Start () 
	{
		player = GetComponentInParent<Player>();
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		button.onClick.AddListener(OnClick);
		button.onClick.AddListener(Spell);


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
	}

	protected virtual void Spell()
	{

	}
	void Update()
	{
		if(player.SpellPoints==0)
		Deactive();
	}

}