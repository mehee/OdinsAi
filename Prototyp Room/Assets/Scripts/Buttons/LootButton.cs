using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private Image icon;
	[SerializeField]
	private Text title;
	[SerializeField]
	private LootWindow lootWindow;

	public Image MyIcon
	{
		get{return icon;}
	}

	public Text MyTitle
	{
		get{return title;}
	}

	public Item MyLoot{get;set;}

	private void Awake()
	{
		lootWindow = GetComponentInParent<LootWindow>();
	}


	//----- Tooltips
	public void OnPointerEnter(PointerEventData eventData)
	{
		UIManager.MyInstance.ShowTooltip(new Vector2(1,0),transform.position, MyLoot);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}
	// Loot it
	public void OnPointerClick(PointerEventData eventData)
	{
		if(InventoryScript.MyInstance.AddItem(MyLoot))
		{
			gameObject.SetActive(false);
			lootWindow.TakeLoot(MyLoot);
			UIManager.MyInstance.HideTooltip();
		}
		
	}
}
