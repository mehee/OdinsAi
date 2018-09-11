using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : Ability
{
	[SerializeField] List<Ability> comboParts;

	[Tooltip("The time in seconds that you have to "
 	+ "press the button again and continue the combo.")]
	[SerializeField] float timeBeforeComboInterrupts;
	int activeComboPart = 0;
	CountDown interruptTimer;
	bool comboContinues;

	public override void SetUp()
	{
		interruptTimer = new CountDown(timeBeforeComboInterrupts);
		for(int i = 0; i < comboParts.Count; i++)
		{
			var instance = comboParts[i].CreateInstance(this.owner);
			instance.transform.parent = this.transform;
			comboParts[i] = instance;
		}
	}

	/** Override to add functionality to the activaton
		of the ability. */
	public override void OnActivation()
	{
		activeComboPart = 0;
		try
		{
			comboParts[0].Activate();
		}
		catch(System.IndexOutOfRangeException)
		{
			Debug.LogError("No ability in List 'comboParts'!");
			Finish();
		}
		activeComboPart++;
		interruptTimer.Start();
	}

	/** This function will be automatically
		called through Update(). It will not
		be called if the ability has finished. 
		Override this to extend the functionality 
		of the base classes Update() method. */
	public override void ResolveOngoingEffects()
	{
		if(ComboIsOver())
		{
			Finish();
			return;
		}

		if(Input.GetButtonDown("Ability1") && (activeComboPart + 1) < comboParts.Count)
			comboContinues = true;

		if(comboParts[activeComboPart].Finished && comboContinues)
		{
			activeComboPart++;
			comboParts[activeComboPart].Activate();
		}

		interruptTimer.ReduceRemainingTime(Time.deltaTime);
	}

	/** Used for cleanup code in case
		your ability gets interrupted. 
		Override to add functionality. */
	public override void CleanUp()
	{
		foreach(Ability comboPart in comboParts)
		{
			comboPart.CleanUp();
		}
	}

	private bool ComboIsOver()
	{
		if(activeComboPart > comboParts.Count)
			return true;
		if(interruptTimer.Finished)
			return true;
		return false;
	}
}
