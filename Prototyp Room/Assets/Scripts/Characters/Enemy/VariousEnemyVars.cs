using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariousEnemyVars : MonoBehaviour {

    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private float chargeTime;
    [SerializeField]
    private float overChargeDistance;

    public float ChargeSpeed
    {
        get
        {
            return ChargeSpeed;
        }

        set
        {
            ChargeSpeed = value;
        }
    }

    public float ChargeTime
    {
        get
        {
            return chargeTime;
        }

        set
        {
            chargeTime = value;
        }
    }

    public float OverChargeDistance
    {
        get
        {
            return overChargeDistance;
        }

        set
        {
            overChargeDistance = value;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
