using System;
using System.Collections.Generic;
using Controllers.InputControllers;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UISettings : UIBase
    {

        public GameObject SoundSlider;
        public Button InputTouchButton;
        public Button InputAccelerometerButton;
        public Button InputDragButton;
        private void Start()
        {
            var id = GameController.GC.Data.InputType;
            if(id != null)
                SetControll(id);
            else 
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
                    SetControlType<InputControllerTouch>();
                    
                    InputTouchButton.interactable = false;
                    InputAccelerometerButton.interactable = true;
                    InputDragButton.interactable = true;
                    
                    break;
                }
                case 1:
                {
                    SetControlType<InputControllerAccelerometer>();
                    
                    InputTouchButton.interactable = true;
                    InputAccelerometerButton.interactable = false;
                    InputDragButton.interactable = true;
                    
                    break;
                }
                case 2:
                {
                    SetControlType<InputControllerDrag>();
                    
                    InputTouchButton.interactable = true;
                    InputAccelerometerButton.interactable = true;
                    InputDragButton.interactable = false;
                    
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