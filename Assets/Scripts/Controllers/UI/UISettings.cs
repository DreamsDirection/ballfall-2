using System;
using System.Collections.Generic;
using Controllers.InputControllers;
using UnityEngine;

namespace Controllers.UI
{
    public class UISettings : MonoBehaviour
    {
        GameController gc => GameController.GC;

        public GameObject SoundSlider;
        private void Start()
        {
            SetControlType<InputControllerTouch>();
        }

        public void SoundMute(bool value)
        {
            SoundSlider.SetActive(value);
            
        }

        public void SoundSliderValueChanged(float value)
        {
            
        }
        public void Return()
        {
            UIController.UI.ShowUI<UIMainMenu>();
        }
        public void SetControll(int id)
        {
            switch (id)
            {
                case 0:
                {   
                    gc.controllType = ControllType.Touch;
                    SetControlType<InputControllerTouch>();
                    break;
                }
                case 1:
                {
                    gc.controllType = ControllType.Accelerometer;
                    SetControlType<InputControllerAccelerometer>();
                    break;
                }
                case 2:
                {
                    gc.controllType = ControllType.Drag;
                    SetControlType<InputControllerDrag>();
                    break;
                }
            }
        
        }

        void SetControlType<T>() where T : InputControllerBase
        {
            Destroy(gc.inputController.GetComponent<InputControllerBase>());
            gc.inputController.AddComponent<T>();
        }
    }
}