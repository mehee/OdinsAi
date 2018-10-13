using UnityEngine;
using AbilitySystem;

public class ThrowRuneOrb : PlayerAbility
{
	[SerializeField]
	Damage damage;

	ObjectPool runeOrbs;

	protected override void SetUp()
	{
		Fireball fireball;
		runeOrbs = GetComponent<ObjectPool>();
		foreach(PoolObject poolObject in runeOrbs.Instances)
		{
			fireball = poolObject as Fireball;
			fireball.stats = owner.stats;
			fireball.damage = damage;
		}
	} 

	protected override void OnActivation()
	{
		var runeOrb = runeOrbs.Dispatch() as Fireball;
		if(runeOrb == null)
		{
			Debug.LogError("No orbs left");
			return;
		}
		runeOrb.transform.position = transform.position;
		runeOrb.direction = direction;
	}
}
