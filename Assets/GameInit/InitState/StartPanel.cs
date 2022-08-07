using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameInit.InitState
{
    public class StartPanel : MonoBehaviour, IActivatable
    {
        [SerializeField] private Button m_ButtonContinue;

        private Action m_ClickCallback;
        
        public void InitCallback(Action callback)
        {
            m_ClickCallback = callback;
            m_ButtonContinue.onClick.RemoveAllListeners();
            m_ButtonContinue.onClick.AddListener(Click);
        }

        public void SetActive()
        {
            gameObject.SetActive(true);
        }

        public void SetInactive()
        {
            gameObject.SetActive(false);
        }

        private void Click()
        {
            m_ClickCallback?.Invoke();
            m_ClickCallback = null;
        }
    }
}