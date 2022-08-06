using System;

namespace JlMetroidvaniaProject.FSM
{
    public abstract class FiniteStateMachine<T_Instance, T_StateEnum>
    where T_Instance : class
    where T_StateEnum : System.Enum
    {
        public T_Instance instance => m_instance;
        public T_StateEnum currentStateEnum => m_currentStateEnum;
        public FiniteState<T_Instance, T_StateEnum> currentState => m_states[m_currentStateIndex];

        private T_Instance m_instance;
        private T_StateEnum m_currentStateEnum;
        private int m_currentStateIndex;
        private int m_stateCount;
        private FiniteState<T_Instance, T_StateEnum>[] m_states;

        public FiniteStateMachine(T_Instance fsmInstance, T_StateEnum initialStateEnum)
        {
            m_instance = fsmInstance;

            int enumCount = Enum.GetValues(typeof(T_StateEnum)).Length;
            m_stateCount = enumCount;

            m_states = new FiniteState<T_Instance, T_StateEnum>[enumCount];

            InitializeStates();
            m_StartMachine(initialStateEnum);
        }

        public void ChangeState(T_StateEnum nextStateEnum)
        {
            m_states[m_currentStateIndex].OnStateFinish();
            m_currentStateEnum = nextStateEnum;
            m_currentStateIndex = nextStateEnum.ToInt32();
            m_states[m_currentStateIndex].OnStateEnter();
        }

        protected abstract void InitializeStates();

        protected void SetStateInstance(FiniteState<T_Instance, T_StateEnum> state)
        {
            m_states[state.type.ToInt32()] = state;
        }

        private void m_StartMachine(T_StateEnum initialStateEnum)
        {
            m_currentStateEnum = initialStateEnum;
            m_currentStateIndex = initialStateEnum.ToInt32();
            OnMachineStart();
        }

        protected virtual void OnMachineStart() {}
        protected virtual void OnStateEnter() {}
        protected virtual void OnStateFinish() {}

        protected bool IsCurrentStateExists()
        {
            return m_states[m_currentStateIndex] != null;
        }
    }
}