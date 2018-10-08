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
    
    // Prolongs life time of already attached bleeding
    // instead of adding another.
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

        if(lifeTime.Remaining <= 0)
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
