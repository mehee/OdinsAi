using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	PlayerScript playerScript;
	Player player;
    Enemy enemy;
    EnemyBehaviour enemyBehaviour;
	Death death;
    private Character chara;
	void Start () 
	{
        death = GetComponent<Death> ();
       if(GetComponent<EnemyBehaviour>()!=null)
        {
            enemyBehaviour = GetComponent<EnemyBehaviour>();
            enemy = enemyBehaviour.Enemy;
        }
       else
        {
		playerScript = GetComponent<PlayerScript> ();
		player = playerScript.Player;
        }
}
	
	public void subtractHealthBy(float value)
	{
        if (enemy != null)
        {
            enemy.subtractHealthBy(value);

            if (enemy.getCurrentHealth() <= 0)
                death.die();
        }
        else
        {
            player.subtractHealthBy(value);

            if (player.CurrentHealth <= 0)
                death.die();
        }
	}


	
}
