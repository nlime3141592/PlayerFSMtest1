using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JlMetroidvaniaProject.FSM
{
    [Serializable]
    public class PlayerStateMachine : FiniteStateMachine<Player, PlayerStateEnum>
    {
        public Player player {get; private set;}
        public Rigidbody2D rigid {get; private set;}
        public float speed {get; private set;} = 3.5f;
        public float jumpForce {get; private set;} = 7.0f;
        public bool isJump = false;
        public Transform transform => player.transform;
        public InputBufferQueue jumpQueue;
        public int jumpQueueFrame = 20;

        public PlayerStateMachine(Player fsmPlayer, PlayerStateEnum initialState)
        : base(fsmPlayer, initialState)
        {
            player = fsmPlayer;
            rigid = fsmPlayer.GetComponent<Rigidbody2D>();

            jumpQueue = new InputBufferQueue(jumpQueueFrame, KeyCode.Space);
        }

        protected override void InitializeStates()
        {
            base.SetStateInstance(new PlayerGroundIdleState(this));
            base.SetStateInstance(new PlayerGroundMoveState(this));
            base.SetStateInstance(new PlayerJumpState(this));
            base.SetStateInstance(new PlayerInAirState(this));
        }

        public virtual void OnUpdate()
        {
            (currentState as PlayerState).OnUpdate();
        }

        public virtual void OnFixedUpdate()
        {
            (currentState as PlayerState).OnFixedUpdate();
            jumpQueue.AddFrame();
        }
    }
}