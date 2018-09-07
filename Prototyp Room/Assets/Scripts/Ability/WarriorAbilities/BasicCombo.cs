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
	int framesTotal;
	
	BoxCollider2D[] hitboxes;

    protected override void SetUp()
	{
		hitboxes = GetComponents<BoxCollider2D>();
		framesPerStep = startupFrames + activeFrames + recoveryFrames;
		framesTotal = framesPerStep * comboLength;
	}

	protected override void OnActivation()
    {
        comboStep = 1;
    }

	protected override void ResolveOngoingEffects()
	{
		if(frameCount > framesPerStep * comboStep)
		{
			NextComboStep();
		}
	}

	protected override void FinishIfDurationOver()
	{
		Finished = (frameCount == framesTotal);
	}

	void NextComboStep()
	{
		if(comboStep < comboLength)
		{
			hitboxes[comboStep - 1].enabled = false;
			comboStep++;
			hitboxes[comboStep - 1].enabled = true;
		}
		else
		{
			FinishIfDurationOver();
		}
	}
}
