using System.Collections;
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
    private int intellect;

    [SerializeField]
    private int strength;

    [SerializeField]
    private int stamina;

    [SerializeField]
    private AnimationClip[] animationClips;

    internal ArmorType MyArmorType
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
}
