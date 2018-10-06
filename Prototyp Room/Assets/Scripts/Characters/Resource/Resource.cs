using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
	[SerializeField]
	protected float maximum;
	[SerializeField]
    float value;

    bool isVulnerable= true;


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

        set
        {
            this.value = value;
        }
    }

    public bool IsVulnerable
    {
        get
        {
            return isVulnerable;
        }

        set
        {
            isVulnerable = value;
        }
    }

    public virtual void Reduce(float amount)
    {
        if(isVulnerable)
        {
        Value -= amount;
        if(Value <= 0)
        {
            Value = 0;
        }
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
        Value = Maximum;
    }
}
