using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** An ability that consists of an
		array of smaller abilities that
		are activated in order if the
		corresponding button is repeatedly
		pressed in the required time frame. */
	public class Combo : Ability
	{
		[SerializeField] List<Ability> comboParts;

		[Tooltip("The amount that you have to "
		+ "press the button again and continue the combo.")]
		[SerializeField] int framesBeforeInterrupt = 30;
		int remainingFramesBeforeInterrupt;
		int activeComboPart = 0;

		protected override void SetUp()
		{
			for(int i = 0; i < comboParts.Count; i++)
			{
				Ability instance = comboParts[i].CreateInstance(this.owner);
				instance.transform.SetParent(this.transform);
				comboParts[i] = instance;
			}
		}

		/** Override to add functionality to the activaton
			of the ability. */
		protected override void OnActivation()
		{
			foreach(Ability comboPart in comboParts)
			{
				comboPart.direction = direction;
			}
			comboParts[activeComboPart].Activate();
			remainingFramesBeforeInterrupt = framesBeforeInterrupt;
		}

		/** This function will be automatically
			called through Update(). It will not
			be called if the ability has finished. 
			Override this to extend the functionality 
			of the base classes Update() method. */
		protected override void ResolveOngoingEffects()
		{
			if(comboParts[activeComboPart].Finished)
			{
				bool comboFinished = (activeComboPart + 1 == comboParts.Count);
				if(remainingFramesBeforeInterrupt == 0 || comboFinished)
				{
					Finish();
					return;
				}

				if(Input.GetButtonDown(associatedButton))
				{
					activeComboPart++;
					comboParts[activeComboPart].Activate();
				}

				remainingFramesBeforeInterrupt--;
			}
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

			remainingFramesBeforeInterrupt = framesBeforeInterrupt;
			activeComboPart = 0;
		}

		// Combo does not have a fixed duration itself,
		// so we leave this empty.
		protected override void FinishIfDurationOver()
		{
			
		}
	}
}
