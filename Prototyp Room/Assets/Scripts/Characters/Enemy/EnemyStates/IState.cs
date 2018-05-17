using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState{
    //Prepare the State
    void Enter(EnemyBehaviour parent);

    void Update();

    void Exit();
}
