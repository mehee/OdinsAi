using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	// Use this for initialization
	Button button;

	private Image icon;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int skillNumber;
	[SerializeField]
	private Ability ability;
	[SerializeField]
	private Image isSkilledIcon;
	private bool isSkilled = false;

    void Start () 
	{
		button = GetComponent<Button>();
		icon = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();

		icon.sprite = ability.icon;
		isSkilledIcon.enabled = false;
	}
	
	// Update is called once per frame

	void Active()
	{
		button.enabled = true;
		icon.color = new Color(1,1,1, 1f);
	}

	void Deactive()
	{
		button.enabled = false;
		icon.color = new Color(1,1,1, 0.5f);
		
	}

	void Update()
	{
		if(player.SpellPoints <= 0)
		{
			player.SpellPoints = 0;
			Deactive();
		}
		else{

			Active();
		}
	}

	//ClickHandler
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left && isSkilled == false && player.SpellPoints > 0)
		{
			isSkilled = true;
			isSkilledIcon.enabled = true;
			player.SpellPoints--;
			abilityKit.SwapSkill(ability,skillNumber);
		}
	}

	// --- Tooltips
	public void OnPointerEnter(PointerEventData eventData)
	{
		if(ability != null)
		{
			UIManager.MyInstance.ShowTooltip(new Vector2(0,0),transform.position, ability);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}
}