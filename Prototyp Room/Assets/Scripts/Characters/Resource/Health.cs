using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Resource 
{
    private bool dmgReceived = false;

    public bool DmgReceived
    {
        get
        {
            return dmgReceived;
        }

        set
        {
            dmgReceived = value;
        }
    }

    public void UpdateHealth(uint hp)
    {
        Maximum += (float) hp;
    }
    public override void Reduce(float amount)
    {
        DmgReceived = true;
        Value -= amount;
        if(Value <= 0)
        {
            GetComponent<Character>().Die();
        }
    }
    
}
