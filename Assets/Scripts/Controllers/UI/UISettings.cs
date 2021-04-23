using System;
using System.Collections.Generic;
using Controllers.InputControllers;
using UnityEngine;

namespace Controllers.UI
{
    public class UISettings : MonoBehaviour
    {
        GameController gc => GameController.GC;

        private void Start()
        {
            SetControlType<InputControllerTouch>();
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