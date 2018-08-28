using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	// ------ Methods
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
			clickable.MyStackText.color = new Color(0,0,0,0);
		}
 
    }
}
