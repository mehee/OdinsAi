﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static UIManager instance;

	// ------ Instanciate himself 
    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

	[SerializeField]
	private GameObject toolTip;
	private Text tooltipText;

	//UI elements to openClose
	[SerializeField]
	private CanvasGroup characterMenu;
	[SerializeField]
	private CanvasGroup spellBook;
	[SerializeField]
	private CanvasGroup mainMenu;
	[SerializeField]
	private RectTransform tooltipRect;

	private void Awake()
	{
		tooltipText = toolTip.GetComponentInChildren<Text>();
	}

	void Update()
	{
		if(Input.GetButtonDown("CharacterMenu"))
		{
			OpenClose(characterMenu);
		}
		if(Input.GetButtonDown("Bags"))
		{
			//has to be different, because we open an actuall bag, not just blend in an CanvasGroup
			InventoryScript.MyInstance.OpenClose();
		}
		if(Input.GetButtonDown("Spellbook"))
		{
			OpenClose(spellBook);
		}
		if(Input.GetButtonDown("Esc"))
		{
			OpenClose(mainMenu);
		}
	}

	/**Set CanvasGroup alpha and blockRayCast */
	public void OpenClose(CanvasGroup canvasGroup)
	{
		canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
		canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
	}

	/**Methode for Bags to Stack Items on Slot */
	public void UpdateStackSize(IClickable clickable)
    {
		//set Text of MyStackText to the Count 
		if(clickable.MyCount > 1)
		{
			clickable.MyStackText.text = clickable.MyCount.ToString();
			clickable.MyStackText.color = Color.white;
			clickable.MyIcon.color = Color.white;	
		}
		//if their is 1 Item left. so reset 1 to nothing
		else
		{
			clickable.MyStackText.color = new Color(0,0,0,0);
		}

		//reset everything to 0 if no item anymore
		if(clickable.MyCount == 0)
		{
			clickable.MyIcon.color = new Color(0,0,0,0);
			clickable.MyBackground.color = new Color(0,0,0,0);
			clickable.MyStackText.color = new Color(0,0,0,0);
		}
 
    }

	//----Tooltips
	///<summary>
	/// Shows the Tooltip of 
	///<param name="position"> Position of the Tooltip </param>
	///<param name="description"> Description of the Item/Ability </param>
	///</summary>
	public void ShowTooltip(Vector2 pivot, Vector3 position, IDescribable description)
	{
		tooltipRect.pivot = pivot;
		toolTip.SetActive(true);
		toolTip.transform.position = position;
		tooltipText.text = description.GetDescription();
	}
	/**Hide Tooltips */
	public void HideTooltip()
	{
		toolTip.SetActive(false);
	}

	/**Refresh Tooltip UI */
	public void RefreshTooltip(IDescribable description)
	{
		tooltipText.text = description.GetDescription();
	}
}
