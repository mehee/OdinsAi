using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public string characterName;
    [TextArea(1, 10)]
    public string description;
	public int level;
	public int maxHealth;
	public float moveSpeed;

    // TODO: Add other stats later
	// when game design is clearer.

    public abstract void Die();
}
