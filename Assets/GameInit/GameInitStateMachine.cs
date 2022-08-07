using System.Collections;
using System.Collections.Generic;
using TD.Assets.GameLevels;
using TD.Assets.InputControl;
using TD.Assets.Waves;
using UnityEngine;
using Zenject;

namespace TD.Assets.GameInit
{
    public class GameInitStateMachine : IInitializable
    {
        [Inject] private IInputService m_InputService;
        [Inject] private IGameLevelsService m_GameLevelsService;
        [Inject] private IWavesService m_WavesService;
        [Inject] private IBaseManager m_BaseManager;
        [Inject] private IWavesProcessor m_WavesProcessor;
        [Inject] private IGameEvents m_GameEvents;
        [Inject] private ICustomLogger m_CustomLogger;

        private bool m_Started = false;

        public void Initialize()
        {
            m_InputService.Click += Clicked;
            m_BaseManager.HealthPointsIsOver += HealthPointsIsOver;
        }

        public void Start()
        {
            var gameLevel = m_GameLevelsService.InitGameLevel(0);
            m_BaseManager.SetBase(gameLevel.GetBase());
            m_WavesService.LoadWavesConfig("");
            m_WavesService.StartWaves(gameLevel.GetPath());
        }

        private void Clicked(Vector2 position)
        {
            if (!m_Started)
            {
                m_Started = true;
                Start();
            }
        }

        private void HealthPointsIsOver()
        {
            m_CustomLogger.LogError($"GameOver, base helth points are other");
        }
    }
}