using System;

namespace JlMetroidvaniaProject.FSM
{
    public abstract class FiniteState<T_Instance, T_StateEnum>
    where T_Instance : class
    where T_StateEnum : System.Enum
    {
        public T_Instance instance => m_fsm.instance;
        public FiniteStateMachine<T_Instance, T_StateEnum> genericFSM => m_fsm;
        public T_StateEnum type => m_stateType;

        private FiniteStateMachine<T_Instance, T_StateEnum> m_fsm;
        private T_StateEnum m_stateType;

        protected FiniteState(FiniteStateMachine<T_Instance, T_StateEnum> fsm, T_StateEnum stateType)
        {
            m_fsm = fsm;
            m_stateType = stateType;
        }

        public virtual void OnStateEnter() {}
        public virtual void OnStateFinish() {}
    }
}