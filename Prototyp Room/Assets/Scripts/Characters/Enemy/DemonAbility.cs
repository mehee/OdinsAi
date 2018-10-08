using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;
public class DemonAbility : MonoBehaviour {

    [SerializeField]
    private EnemyAbility ability;

    public EnemyAbility Ability
    {
        get
        {
            return ability;
        }

        set
        {
            ability = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
