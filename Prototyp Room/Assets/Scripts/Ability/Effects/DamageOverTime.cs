using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/DoT")]
public class DamageOverTime : TemporaryEffect
{
    public override PersistentEffect Clone()
    {
        return DamageOverTime.Instantiate(this);
    }
}
