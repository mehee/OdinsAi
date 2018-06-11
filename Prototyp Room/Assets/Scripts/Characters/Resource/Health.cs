using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Resource 
{   
    //private bool isHit = false;
    public void UpdateHealth(uint hp)
    {
        Maximum += (float) hp;
    }
    public override void Reduce(float amount)
    {
        //isHit = true;
        Value -= amount;
        if(Value <= 0)
        {
            GetComponent<Character>().Die();
        }
    } 
    
}
