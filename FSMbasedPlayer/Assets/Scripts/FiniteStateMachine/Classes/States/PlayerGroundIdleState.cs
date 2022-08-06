using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JlMetroidvaniaProject.FSM
{
    public class PlayerState : FiniteState<Player, PlayerStateEnum>
    {
        public PlayerStateMachine playerFSM => m_fsm;
        private PlayerStateMachine m_fsm;

        protected PlayerState(PlayerStateMachine fsm, PlayerStateEnum initialState)
        : base(fsm, initialState)
        {
            m_fsm = fsm;
        }

        public virtual void OnUpdate() {}
        public virtual void OnFixedUpdate() {}
    }

    public class PlayerGroundIdleState : PlayerState
    {
        public PlayerGroundIdleState(PlayerStateMachine fsm)
        : base(fsm, PlayerStateEnum.GroundIdle)
        {

        }

        public override void OnStateEnter()
        {
            foreach(KeyCode jumpKey in playerFSM.jumpQueue.DequeueKeys())
            {
                if(jumpKey == KeyCode.Space)
                {
                    playerFSM.jumpQueue.Flush();
                    playerFSM.ChangeState(PlayerStateEnum.BasicJump);
                }
            }
        }

        public override void OnUpdate()
        {
            if(MyInputHandler.xInput)
            {
                playerFSM.ChangeState(PlayerStateEnum.GroundMove);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerFSM.ChangeState(PlayerStateEnum.BasicJump);
            }
        }

        public override void OnFixedUpdate()
        {
            playerFSM.rigid.gravityScale = 1.0f;
            playerFSM.rigid.velocity = new Vector2(0, playerFSM.rigid.velocity.y);
        }
    }

    public class PlayerGroundMoveState : PlayerState
    {
        public PlayerGroundMoveState(PlayerStateMachine fsm)
        : base(fsm, PlayerStateEnum.GroundMove)
        {

        }

        public override void OnUpdate()
        {
            if(!MyInputHandler.xInput)
            {
                playerFSM.ChangeState(PlayerStateEnum.GroundIdle);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerFSM.ChangeState(PlayerStateEnum.BasicJump);
            }
        }

        public override void OnFixedUpdate()
        {
            int dir = 0;
            if(MyInputHandler.lInput) dir -= 1;
            if(MyInputHandler.rInput) dir += 1;

            playerFSM.rigid.gravityScale = 1.0f;
            playerFSM.rigid.velocity = new Vector2(playerFSM.speed * dir, playerFSM.rigid.velocity.y);
        }
    }

    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(PlayerStateMachine fsm)
        : base(fsm, PlayerStateEnum.BasicJump)
        {

        }

        public override void OnStateEnter()
        {
            playerFSM.rigid.AddForce(Vector2.up * playerFSM.jumpForce, ForceMode2D.Impulse);
            playerFSM.ChangeState(PlayerStateEnum.InAir);
            playerFSM.isJump = true;
        }
    }

    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerStateMachine fsm)
        : base(fsm, PlayerStateEnum.InAir)
        {

        }

        public override void OnFixedUpdate()
        {
            if(!playerFSM.isJump && Physics2D.Raycast(playerFSM.transform.position, Vector2.down, 0.55f, 1 << LayerMask.NameToLayer("Ground")))
                playerFSM.ChangeState(PlayerStateEnum.GroundIdle);
            if(playerFSM.rigid.velocity.y <= 0)
                playerFSM.isJump = false;
            
            // in air x-move
            int dir = 0;
            if(MyInputHandler.lInput) dir -= 1;
            if(MyInputHandler.rInput) dir += 1;

            playerFSM.rigid.gravityScale = 1.0f;
            playerFSM.rigid.velocity = new Vector2(playerFSM.speed * dir, playerFSM.rigid.velocity.y);
        }

        public override void OnUpdate()
        {
            playerFSM.jumpQueue.EnqueueKeys();
        }
    }
}