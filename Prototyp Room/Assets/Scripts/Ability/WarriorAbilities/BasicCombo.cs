using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The basic attack of the player. Click
	LMB in rapid succession to chain quick 
	strikes together. */
public class BasicCombo : Ability
{
	public int comboLength = 3;
	int comboStep = 1;
	int framesPerStep;
	int frameCounter = 0;
	
	BoxCollider2D[] hitboxes;

    protected override void SetUp()
	{
		hitboxes = GetComponents<BoxCollider2D>();
		framesPerStep = startupFrames + activeFrames + recoveryFrames;
	}

	protected override void OnActivation()
    {
        comboStep = 1;
    }

	protected override void ResolveOngoingEffects()
	{
		frameCounter++;

		if(frameCounter > framesPerStep * comboStep)
		{
			NextComboStep();
		}
	}

	void Strike()
	{
		hitboxes[comboStep - 1].enabled = true;
	}

	void NextComboStep()
	{
		if(comboStep < comboLength)
		{
			comboStep++;
		}
		else
		{
			
		}
	}
}
