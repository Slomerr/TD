using TD.Assets.InputControl;
using UnityEngine;
using Zenject;

namespace TD.Assets.Towers
{
    public class TowersManager : ITowersManager, IInitializable
    {
        private const float m_CellDelta = 0.5f;

        [Inject] private IInputService m_InputService;
        [Inject] private ITowersFactoryManager m_FactoryManager;
        [Inject] private ICustomLogger m_CustomLogger;

        public void Initialize()
        {            
            m_InputService.Click += Clicked;
        }

        private void Clicked(Vector2 clickPosition)
        {
            var position = Camera.main.ScreenToWorldPoint(clickPosition - new Vector2(0.5f, 0.5f));
            var targetPosition = new Vector2Int((int)(position.x + m_CellDelta), (int)(position.y + m_CellDelta));
            m_CustomLogger.Log($"Towers >>> Try create tower for position on screen [{position}], on world INT [{targetPosition}]");
            m_FactoryManager.Create(targetPosition);
        }
    }
}
