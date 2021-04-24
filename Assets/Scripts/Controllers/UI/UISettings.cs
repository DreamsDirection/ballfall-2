﻿using System;
using System.Collections.Generic;
using Controllers.InputControllers;
using UnityEngine;

namespace Controllers.UI
{
    public class UISettings : UIBase
    {

        public GameObject SoundSlider;
        private void Start()
        {
            SetControlType<InputControllerTouch>();
        }
        
        public override void Open()
        {
            
        }

        public override void Close()
        {
            
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
                    GC.controllType = ControllType.Touch;
                    SetControlType<InputControllerTouch>();
                    break;
                }
                case 1:
                {
                    GC.controllType = ControllType.Accelerometer;
                    SetControlType<InputControllerAccelerometer>();
                    break;
                }
                case 2:
                {
                    GC.controllType = ControllType.Drag;
                    SetControlType<InputControllerDrag>();
                    break;
                }
            }
        
        }

        void SetControlType<T>() where T : InputControllerBase
        {
            Destroy(GC.inputController.GetComponent<InputControllerBase>());
            GC.inputController.AddComponent<T>();
        }
    }
}