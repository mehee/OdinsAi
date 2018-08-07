using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : StatusEffect
{
    public int damage;

    public override void Apply()
    {
        transform.parent.GetComponent<Health>().Reduce(damage);
    }
    
    public override void Attach(Transform target)
    {
        var oldStatus = target.GetComponentInChildren<Bleed>();
        if(oldStatus)
        {
            oldStatus.RemainingDuration += Duration;
        }
        else
        {
            base.Attach(target);
        }
    }

    void Update()
    {
        float time = Time.time;
        
        if(remainingDuration == 0)
        {
            Destroy(gameObject);
        }

        if(time - lastApplicationTime >= interval)
        {
            Apply();
            lastApplicationTime = time;
        }

        if(remainingDuration >0)
        {
            remainingDuration -= Time.deltaTime;
            if(remainingDuration < 0)
                remainingDuration = 0;
        }
    }
}
