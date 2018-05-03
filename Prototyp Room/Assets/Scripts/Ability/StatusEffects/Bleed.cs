using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : StatusEffect
{
    GameObject target;
    public int damage;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public override void Apply()
    {
        transform.parent.GetComponent<Health>().Reduce(damage);
    }

    void Update()
    {
        float time = Time.time;
        if(time - creationTime >= Duration)
        {
            Debug.Log("Duration over");
            Destroy(gameObject);
        }

        if(time - lastApplicationTime >= interval)
        {
            Apply();
            lastApplicationTime = time;
        }
    }
}
