using System;

namespace FSM
{
    public class StateIdentifier : Attribute
    {
        private Type m_StateType;

        public Type StateType
        {
            get => m_StateType;
        }
        
        public StateIdentifier(Type stateType)
        {
            m_StateType = stateType;
        }
    }
}