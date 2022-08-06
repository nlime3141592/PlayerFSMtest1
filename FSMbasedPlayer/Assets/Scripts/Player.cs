using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JlMetroidvaniaProject.FSM;

public class Player : MonoBehaviour
{
    public PlayerStateMachine m_machine;

    void Start()
    {
        m_machine = new PlayerStateMachine(this, PlayerStateEnum.GroundIdle);
    }

    void Update()
    {
        m_machine.OnUpdate();
    }

    void FixedUpdate()
    {
        m_machine.OnFixedUpdate();
    }
}
