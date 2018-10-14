using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 3)]
public class Weapon : Item
{
    /*
    [SerializeField]
    private WeaponType weaponType;

	[SerializeField]
	private int damage;
	
	[SerializeField]
    private int intellect;

    [SerializeField]
    private int strength;

    [SerializeField]
    private int stamina;

    [SerializeField]
    private AnimationClip[] animationClips;

    internal WeaponType MyWeaponType
    {
        get {return weaponType;}
    }

    public AnimationClip[] MyAnimationClips
    {
        get {return animationClips;}
    }

    public override string GetDescription()
    {
        string stats = string.Empty;

        stats += string.Format("\n{0}", ArmorTypClass.MyWeaponType[weaponType]);

		if (damage > 0 )
        {
            stats += string.Format("\n{0} Damage", damage);
        }
        if (intellect > 0 )
        {
            stats += string.Format("\n+{0} Intellect", intellect);
        }
        if (strength > 0)
        {
            stats += string.Format("\n+{0} Strength", strength);
        }
        if (stamina > 0)
        {
            stats += string.Format("\n+{0} Stamina", stamina);
        }

        return base.GetDescription() +stats;
    }

    public void Equip()
    {
       // CharacterPanel.MyInstance.EquipArmor(this);
    }
     */
}
