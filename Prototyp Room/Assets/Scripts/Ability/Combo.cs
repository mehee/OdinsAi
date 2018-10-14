using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    /** An ability that consists of an
		array of smaller abilities that
		are activated in order if the
		corresponding button is repeatedly
		pressed in the required time frame. */
    public class Combo : PlayerAbility
	{
		public List<Ability> comboParts;

		[Tooltip("The amount that you have to "
		+ "press the button again and continue the combo.")]
		[SerializeField] 
		int framesBeforeInterrupt = 30;

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

		protected override void OnActivation()
		{
			foreach(Ability comboPart in comboParts)
			{
				comboPart.direction = direction;
			}
			comboParts[activeComboPart].Activate();
			remainingFramesBeforeInterrupt = framesBeforeInterrupt;
		}

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

		protected override void CleanUp()
		{
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
