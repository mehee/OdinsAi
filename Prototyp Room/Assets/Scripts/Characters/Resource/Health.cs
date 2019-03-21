using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Resource 
{
    private bool dmgReceived = false;

    public bool hasParticleEffect=false;

    public bool hasDmgText=false;

    Text[] text = new Text[2];
     int index=0;
   

    void Start()
    {
        Reset();
        if(hasDmgText)
        {
           Text[] texts = GetComponentsInChildren<Text>();
            foreach (Text v in texts)
            {
                if (v.tag=="DmgText")
                text[index++]= v;
            }

        }
    }

    void Update()
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
        if (hasParticleEffect)
        {
            int randomNumber = Random.Range(0, 10) % 3;
            //GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
            //GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
            //GetComponentsInChildren<ParticleSystem>()[randomNumber++].Play();
        }

        if (hasDmgText)
        {
            index = ++index % 2;
            //text[index].text = amount.ToString();
            //text[index].CrossFadeAlpha(1.0f, 0.01f, false);
            //text[index].CrossFadeAlpha(0.0f, 1, false);
        }
        Value -= amount;
        if (Value <= 0)
        {
            GetComponent<Character>().Die();
        }


    }
}
