using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandScript : MonoBehaviour 
{
	private static HandScript instance;
    //singleton to use easly
    public static HandScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HandScript>();
            }

            return instance;
        }
    }

	//The current moveable
	public IMoveable MyMoveable { get; set; }

	// Icon to drag and drop
	private Image icon;

    //so the icon is not placed over the mouse
    [SerializeField]
    private Vector3 offset;

	void Start()
	{
		icon = GetComponent<Image>();
	}

	void Update()
	{
		icon.transform.position = Input.mousePosition + offset;
		DeleteItem();
	}

    public void TakeMoveable(IMoveable moveable)
    {
        this.MyMoveable = moveable;
        icon.sprite = moveable.MyIcon; //access the icon of the moveable
        icon.color = Color.white;
    }

    public IMoveable Put()
    {
        IMoveable tmp = MyMoveable;
        MyMoveable = null;
        icon.color = new Color(0, 0, 0, 0);
        return tmp;
    }

    public void Drop()
    {
        MyMoveable = null;
        icon.color = new Color(0, 0, 0, 0);
    }

    // Deletes an item from the inventory
    private void DeleteItem()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && MyInstance.MyMoveable != null)
        {
            if (MyMoveable is Item && InventoryScript.MyInstance.FromSlot != null)
            {
                (MyMoveable as Item).MySlot.Clear();
            }

            Drop();

            InventoryScript.MyInstance.FromSlot = null;
        }
    }
}
