using FSM;
using TD.Assets.GameLevels;
using TD.Assets.Waves;
using Zenject;

namespace TD.Assets.GameInit.CoreState
{
    [StateIdentifier(typeof(CoreGamePlay))]
    public class CoreStateManager : IInitializable, IStateManager
    {
        [Inject] private IGameLevelsService m_GameLevelsService;
        [Inject] private IWavesService m_WavesService;
        [Inject] private IBaseManager m_BaseManager;
        [Inject] private ICustomLogger m_CustomLogger;

        private bool m_Started = false;

        public void ActivateState()
        {
            var gameLevel = m_GameLevelsService.InitGameLevel(0);
            m_BaseManager.SetBase(gameLevel.GetBase());
            m_WavesService.LoadWavesConfig("");
            m_WavesService.StartWaves(gameLevel.GetPath());
        }

        public void DeactivateState()
        {
            
        }
        
        public void Initialize()
        {
            m_BaseManager.HealthPointsIsOver += HealthPointsIsOver;
        }

        private void HealthPointsIsOver()
        {
            m_CustomLogger.LogError($"GameOver, base health points are other");
        }
    }
}