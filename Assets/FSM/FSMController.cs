using System;
using System.Collections.Generic;
using Zenject;

namespace FSM
{
    public class FSMController : IInitializable, IFSMController
    {
        [Inject] private List<IStateManager> m_StateManagers;
        [Inject] private ICustomLogger m_CustomLogger;

        private Type m_CurrentState; 
        
        private Dictionary<Type, IStateManager> m_ManagersMap;

        public void Initialize()
        {
            ConfigureMap();
            
            SelectState<TestState>();
        }

        public void SelectState<TState>() where TState : IState
        {
            var newState = typeof(TState);
            if (m_CurrentState == newState)
            {
                m_CustomLogger.Log($"Trying activate state [{nameof(TState)}," +
                                   $"but this state is already activated]");
                return;
            }
            
            if (!m_ManagersMap.ContainsKey(newState))
            {
                m_CustomLogger.LogError($"Map of {nameof(IStateManager)} does not contain value " +
                                        $"with key {nameof(TState)}");
                return;
            }

            if (m_CurrentState != null)
            {
                m_ManagersMap[m_CurrentState].DeactivateState();
            }

            m_CurrentState = newState;
            m_ManagersMap[m_CurrentState].ActivateState();
        }

        private void ConfigureMap()
        {
            m_ManagersMap = new Dictionary<Type, IStateManager>();
            var typeAttribute = typeof(StateIdentifier);
            foreach (var manager in m_StateManagers)
            {
                var attributes = manager.GetType().GetCustomAttributes(typeAttribute, false);
                foreach (var attribute in attributes)
                {
                    if (attribute is StateIdentifier identifier)
                    {
                        AddToMap(manager, identifier);
                    }
                }
            }
        }

        private void AddToMap(IStateManager manager, StateIdentifier identifier)
        {
            if (m_ManagersMap.ContainsKey(identifier.StateType))
            {
               m_CustomLogger.LogError($"Map of {nameof(IStateManager)} already contain {nameof(IStateManager)}" +
                                       $"({m_ManagersMap[identifier.StateType]}), with state type {identifier.StateType}" +
                                       $"current ({manager.GetType()})");
               return;
            }
            
            m_ManagersMap.Add(identifier.StateType, manager);
        }
    }   
}