using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Resource 
{
    private bool dmgReceived = false;

    public bool hasParticleEffect=false;

    public bool hasDmgText=false;

    Text text;

   

    void Start()
    {
       if(hasDmgText)
        {
           Text[] texts = GetComponentsInChildren<Text>();
           foreach(Text v in texts)
           if(v.tag=="DmgText")
            text = v;
            Debug.Log(text.tag);
        }
      
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
        if(hasParticleEffect)
        {
        int randomNumber = Random.Range(0,10) % 3;       
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        }

        if(hasDmgText)
        {
            
             text.text= amount.ToString();
             text.CrossFadeAlpha(1.0f, 0.01f, false);
                text.CrossFadeAlpha(0.0f, 1, false);
        }
        Value -= amount;
        if(Value <= 0)
        {
            GetComponent<Character>().Die(); 
    }
    
}
}
