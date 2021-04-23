
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController UI;
        [SerializeField]private UIGame gameUI;
        [SerializeField]private UISettings settingsUI;
        [SerializeField]private UIShop shopUI;
        [SerializeField]private UIGameOver gameOverUI;
        [SerializeField]private UIMainMenu mainMenuUI;
        private HashSet<MonoBehaviour> l_ui = new HashSet<MonoBehaviour>();

        private void Awake()
        {
            if (!UI) UI = this;
            else Destroy(this);
        }

        private void Start()
        {
            Init();
        }

        void Init()
        {
            l_ui.Add(gameUI);
            l_ui.Add(settingsUI);
            l_ui.Add(shopUI);
            l_ui.Add(gameOverUI);
            l_ui.Add(mainMenuUI);
            ShowUI<UIMainMenu>();
        }
        public void ShowUI<T>() where T : MonoBehaviour
        {
            foreach (var ui in l_ui)
            {
                if(ui is T) ui.gameObject.SetActive(true);
                else ui.gameObject.SetActive(false);
            }
        }

        public T GetUI<T>() where T : MonoBehaviour
        {
            try
            {
                foreach (var ui in l_ui)
                    if (ui is T) return ui as T;
                
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
