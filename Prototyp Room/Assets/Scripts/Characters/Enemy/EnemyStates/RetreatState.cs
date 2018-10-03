﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : IState {

    EnemyBehaviour parent;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {
       // parent.Movement.MovementSpeed = 0;
    }


    public void Update()
    {
        Vector2 movementVec = (parent.MyStartPosition - parent.transform.position).normalized;
        parent.Movement.Move(movementVec);
        float distance = Vector2.Distance(parent.MyStartPosition, parent.transform.position);
        if(distance <=1 )
        {      
            parent.ChangeState(new IdleState());
        }
        if(parent.Target)
        {
            parent.ChangeState(new FollowState());
        }
    }
}