using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour {

	// Use this for initialization

	private Image image;
	private EnemyBehaviour enemyBehaviour;
	private Enemy enemy;

	void Start ()
	 {
		image = GetComponent<Image> ();
		enemyBehaviour = GetComponentInParent<EnemyBehaviour> ();
		enemy = enemyBehaviour.Enemy;
	}
	
	// Update is called once per frame
	void Update () 
	{
		image.fillAmount =  Mathf.Lerp(image.fillAmount,(float)enemy.CurrentHealth/enemy.getMaxHealth(),0.05f);
	}
}
