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
	bool comboContinues = false;
	
	BoxCollider2D[] hitboxes;

	protected override void CleanUp()
	{
		DisableHitboxes();
	}

    protected override void SetUp()
	{
		hitboxes = GetComponents<BoxCollider2D>();
		DisableHitboxes();
		framesPerStep = startupFrames + activeFrames + recoveryFrames;
		framesTotal = framesPerStep * comboLength;
	}

	protected override void OnActivation()
    {
        comboStep = 1;
		hitboxes[comboStep - 1].enabled = true;
    }

	protected override void ResolveOngoingEffects()
	{
		if(Input.GetButtonDown("Ability1"))
			comboContinues = true;
		
		AlignWithMouse();

		if((frameCount > framesPerStep * comboStep) && comboContinues)
		{
			NextComboStep();
			comboContinues = false;
		}
		else
		{
			Finish();
		}
	}

	protected override void FinishIfDurationOver()
	{
		if(frameCount == framesTotal)
			Finish();
		comboContinues = false;
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

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			other.gameObject.GetComponent<Health>().Reduce(Damage);
		}
	}

	void DisableHitboxes()
	{
		foreach(BoxCollider2D collider in hitboxes)
		{
			collider.enabled = false;
		}
	}
}
