using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Resource 
{
    private bool dmgReceived = false;

   

    void Start()
    {
      
    }
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
        int randomNumber = Random.Range(0,10) % 3;       
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        Value -= amount;
        if(Value <= 0)
        {
            GetComponent<Character>().Die();
        }
    }
    
}
