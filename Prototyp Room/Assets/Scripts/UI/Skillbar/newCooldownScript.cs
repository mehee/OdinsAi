using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace AbilitySystem
{

public class newCooldownScript : MonoBehaviour 
{
		private Image cdImage;
		private PlayerAbility playerAbility;

		void Start()
		{
			cdImage = GetComponent<Image>();
		}

		internal void SetAbility(PlayerAbility playerAbility)
		{
			this.playerAbility = playerAbility;
		}

		void Update()
		{
			if(playerAbility != null)
			{
				float remainingCD = playerAbility.Cooldown.Remaining / playerAbility.Cooldown.Duration;
				cdImage.fillAmount = remainingCD;
			}
		}
    }

}