using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	// Use this for initialization
	Button button;

	public ButtonScript neededButton=null;

	private Image icon;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int availableAtLvl;
	public int skillNumber;
	[SerializeField]
	private Ability ability;
	[SerializeField]
	private Image isSkilledIcon;

	public bool isReadytoSkill=false;
	private bool isSkilled = false;

    public bool IsSkilled
    {
        get
        {
            return isSkilled;
        }

        set
        {
            isSkilled = value;
        }
    }

    void Start () 
	{
		button = GetComponent<Button>();
		icon = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();

		icon.sprite = ability.icon;
		isSkilledIcon.enabled = false;
		Deactive();
	}
	
	// Update is called once per frame

	void Active()
	{
		Debug.Log((availableAtLvl==player.level) && (neededButton.isReadytoSkill));
		if(Validate())
		{
		button.enabled = true;
		icon.color = new Color(1,1,1, 1f);
		}
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
			Deactive();
		}
		else
		{

			Active();
		}
	}

	//ClickHandler
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left && isSkilled == false && player.SpellPoints > 0)
		{
			if(Validate())
			{
			--player.SpellPoints;
			IsSkilled = true;
			isReadytoSkill=true;
			isSkilledIcon.enabled = true;
			abilityKit.SwapSkill(ability,skillNumber);
			}
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

	private bool Validate()
	{
		bool retVal=false;
		if((player.SpellPoints>0)&&(IsSkilled==false)&&(player.level>=availableAtLvl)&&(neededButton.isReadytoSkill))
		retVal=true;
		
		
			
		return retVal;

	}
}