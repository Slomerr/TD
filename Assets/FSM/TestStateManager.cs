using Zenject;

namespace FSM
{
    [StateIdentifier(typeof(TestState))]
    public class TestStateManager : IStateManager
    {
        [Inject] private ICustomLogger m_CustomLogger;
        
        public void ActivateState()
        {
            m_CustomLogger.Log($"Activate state {nameof(TestState)}");
        }

        public void DeactivateState()
        {
            m_CustomLogger.Log($"Deactivate state {nameof(TestState)}");
        }
    }
}