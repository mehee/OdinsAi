using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Experience : MonoBehaviour
{
    private PlayerScript playerScript;
    private Player player;

    private uint currentExp = 0;

    //	Death die;
    void Start()
    {
        playerScript = GetComponent<PlayerScript>();
        player = playerScript.Player;
    }

    public void addExp(uint value)
    {
        currentExp+= value;
        if(currentExp> player.getCurrentLvl()*200)
        {
            currentExp = currentExp- player.getCurrentLvl()*200;
            player.lvlUp();
            
        }
    }

    public uint getCurrentExperience()
    {
        return currentExp;
    }

    public uint getNextLvlExp()
    {
        return player.getCurrentLvl()*200;
    }




}