using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;



public class ButtonScript : Ability, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

	// Use this for initialization
	Button button;
	Image image;

	// [SerializeField]
	// private Playstyle playstyle;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int skillNumber;
	[SerializeField]
	private Ability ability;
	
    void Start () 
	{
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();
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

	void Update()
	{
		if(player.SpellPoints==0)
		{}
		// Deactive();
	}

	//ClickHandler
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left)
		{
			player.SpellPoints--;
			abilityKit.SwapSkill(ability,skillNumber);
		}
	}

	// --- Tooltips
	public void OnPointerEnter(PointerEventData eventData)
	{
		UIManager.MyInstance.ShowTooltip(new Vector2(0,0),transform.position, ability);
		if(ability != null)
		{
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}

	public override string GetDescription()
	{
		return base.GetDescription();// + string.Format("Playstyle: <color=#ff0000ff>{0}</color>", Playstyle.warrior);
	}
}