using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootWindow : MonoBehaviour 
{
	// ----- SINGLETON

		private static LootWindow instance;

		public static LootWindow MyInstance
		{
			get
			{
				if(instance == null)
				{
					instance = GameObject.FindObjectOfType<LootWindow>();
				}
				return instance;
			}
		}

	// -----


	[SerializeField]
	private LootButton[] lootButtons;

	private CanvasGroup canvasGroup;

	//List of List of Items, because every page has an own List of Items
	private List<List<Item>> pages = new List<List<Item>>();
	//All dropped Loot
	private List<Item> droppedLoot = new List<Item>();

	//current pageIndex
	private int pageIndex = 0;

	[SerializeField]
	private Text pageNumber;

	[SerializeField]
	private GameObject nextBtn, previousBtn;

	//debugging Only
	[SerializeField]
	private Item[] items;

	public bool IsOpen
	{
		get {return canvasGroup.alpha >0;}
	}

	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	// Use this for initialization
	void Start () 
	{	

	}

	public void CreatePages(List<Item> items)
	{
		if(!IsOpen)
		{
			List<Item> page = new List<Item>();
			//fill the droppedLoot list with the Items of the Page
			droppedLoot = items;

			for (int i = 0; i < items.Count; i++)
			{
				page.Add(items[i]);
				//because we can just have 4 Items at 1 Page
				if(page.Count == 4 || i == items.Count -1 )
				{	
					pages.Add(page);
					page = new List<Item>();
				}
			}

			AddLoot();
			Open();
		}

	}
	
	private void AddLoot()
	{
		if(pages.Count > 0)
		{	
			// Handle page numbers
			pageNumber.text = pageIndex +1+ "/" + pages.Count;

			// Handle next and prev Buttons
			previousBtn.SetActive(pageIndex >0);
			nextBtn.SetActive(pages.Count > 1 && pageIndex < pages.Count -1); //if their are more then 1 page && we are not on the last page -> show nextBtn

			for (int i = 0; i < pages[pageIndex].Count; i++) //on which pageIndex are we 
			{
				if(pages[pageIndex][i] != null) //zero items
				{
					//Set the loot button icon
					lootButtons[i].MyIcon.sprite = pages[pageIndex][i].MyIcon;

					lootButtons[i].MyLoot = pages[pageIndex][i];

					//make it visible
					lootButtons[i].gameObject.SetActive(true);
					//set title with correct QualityColor
					string title = string.Format("<color={0}>{1}</color>", QualityColors.MyColors[pages[pageIndex][i].MyQuality], pages[pageIndex][i].MyTitle);
					lootButtons[i].MyTitle.text = title;
				}
			}
		}
	}

	public void ClearButtons()
	{
		foreach (LootButton btn in lootButtons)
		{
			btn.gameObject.SetActive(false);
		}
	}

	public void NextPage()
	{	
		//check if their are more pages
		if(pageIndex < pages.Count -1)
		{
			pageIndex++;
			ClearButtons();
			AddLoot();
		}
	}

	public void PreviousPage()
	{
		//check if we have more pages to go back
		if(pageIndex > 0)
		{
			pageIndex--;
			ClearButtons();
			AddLoot();
		}
	}

	public void TakeLoot(Item loot)
	{
		pages[pageIndex].Remove(loot);

		//remove the looted Items from the List
		droppedLoot.Remove(loot);

		if(pages[pageIndex].Count ==0)
		{
			//removes empty page
			pages.Remove(pages[pageIndex]);

			if(pageIndex == pages.Count && pageIndex > 0)
			{
				pageIndex--;
			}
			//Update Lootwindow
			AddLoot();
		}
	}

	public void Open()
	{
		canvasGroup.alpha = 1;
		canvasGroup.blocksRaycasts = true;
	}

	public void Close()
	{
		pages.Clear(); // Removed looted Items
		canvasGroup.alpha = 0;
		canvasGroup.blocksRaycasts = false;
		ClearButtons();
	}


}
