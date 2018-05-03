using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
	[SerializeField]
	float maximum;
	[SerializeField]
    float value;

    public float Maximum
    {
        get
        {
            return maximum;
        }
        set
        {
            maximum = value;
            if(maximum <= 0)
                throw new UnityException("Maximum health can't be lower than 1!");
        }
    }

    public float Value
    {
        get
        {
            return value;
        }

        protected set
        {
            this.value = value;
        }
    }

    public virtual void Reduce(float amount)
    {
        Value -= amount;
        if(Value <= 0)
        {
            Value = 0;
        }
    }

    public virtual void Replenish(float amount)
    {
        Value += amount;
        if(Value > maximum)
            Value = maximum;
    }

    public void Reset()
    {
        Value = maximum;
    }

    void Start()
    {
        Maximum = GetComponent<Character>().maxHealth;
        Value = Maximum;
    }
}
