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
            oldStatus.lifeTime.Remaining += lifeTime.Duration;
        }
        else
        {
            base.Attach(target);
        }
    }

    void Update()
    {
        float time = Time.time;
        
        if(!lifeTime.IsActive)
        {
            Destroy(gameObject);
        }

        if(time - lastApplicationTime >= interval)
        {
            Apply();
            lastApplicationTime = time;
        }
    }
}
