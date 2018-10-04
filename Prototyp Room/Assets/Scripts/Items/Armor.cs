﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 2)]
public class Armor : Item
{
    [SerializeField]
    private ArmorType armorType;
    
    [SerializeField]
    private int armor;

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

    public ArmorType MyArmorType
    {
        get {return armorType;}
    }

    public AnimationClip[] MyAnimationClips
    {
        get {return animationClips;}
    }

  
    public override string GetDescription()
    {
        string stats = string.Empty;

        stats += string.Format("\n{0}", ArmorTypClass.MyArmorType[armorType]);

        if (armor > 0 )
        {
            stats += string.Format("\n{0} Armor", armor);
        }
        if (damage > 0 )
        {
            stats += string.Format("\n{0} Danage", damage);
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

    /**Methode to equip item in CharacterMenu Slots
        have to check which slot */
    public void Equip()
    {
       CharacterMenu.MyInstance.EquipArmor(this);
    }
}
