using FSM;
using TD.Assets.GameInit.CoreState;
using Zenject;

namespace GameInit.InitState
{
    [StateIdentifier(typeof(InitState))]
    public class InitStateManager : IStateManager, IInitializable
    {
        [Inject] private StartPanel m_StartPanel;
        [Inject] private IFSMController m_FsmController;
        
        public void ActivateState()
        {
            m_StartPanel.SetActive();
        }

        public void DeactivateState()
        {
            m_StartPanel.SetInactive();
        }

        public void Initialize()
        {
            m_StartPanel.InitCallback(SwitchState);
            m_FsmController.SelectState<InitState>();
        }

        private void SwitchState()
        {
            m_FsmController.SelectState<CoreGamePlay>();
        }
    }
}