using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;

public class GroundSkillScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	// Use this for initialization
	private Image icon;

	[SerializeField]
	protected Player player;
	protected AbilityKit abilityKit;

	public int skillNumber;
	
	[SerializeField]
	private Ability ability;

    void Start () 
	{
		icon = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();

		icon.sprite = ability.icon;
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