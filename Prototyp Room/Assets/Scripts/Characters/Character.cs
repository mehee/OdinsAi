using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public string characterName;
  
	public uint level;

    public Stats stats;

    public abstract void Die();
}
