using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public string characterName;
  
	public uint level;

    public Health healthPool;

     public Stats stats;

    // TODO: Add other stats later
	// when game design is clearer.

    public abstract void Die();
}
