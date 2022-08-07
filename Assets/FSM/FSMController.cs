using System;
using System.Collections.Generic;
using Zenject;

namespace FSM
{
    public class FSMController : IInitializable, IFSMController
    {
        [Inject] private List<IStateManager> m_StateManagers;
        [Inject] private ICustomLogger m_CustomLogger;

        private Dictionary<Type, IStateManager> m_ManagersMap;

        public void Initialize()
        {
            m_ManagersMap = new Dictionary<Type, IStateManager>();
            var typeAttribute = typeof(StateIdentifier);
            foreach (var manager in m_StateManagers)
            {
                var attributes = m_StateManagers.GetType().GetCustomAttributes(typeAttribute, false);
                foreach (var attribute in attributes)
                {
                    if (attribute is StateIdentifier identifier)
                    {
                        AddToMap(manager, identifier);
                    }
                }
            }
        }

        public void SelectState<TState>() where TState : IState
        {
            m_CustomLogger.Log(nameof(TState));
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