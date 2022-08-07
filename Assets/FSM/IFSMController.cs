namespace FSM
{
    public interface IFSMController
    {
        void SelectState<TState>() where TState : IState;
    }
}