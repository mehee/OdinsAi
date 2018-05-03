using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Resource 
{   
    public override void Reduce(float amount)
    {
        Value -= amount;
        if(Value <= 0)
        {
            GetComponent<Character>().Die();
        }
    } 
}
