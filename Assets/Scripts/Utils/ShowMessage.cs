using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class ShowMessage : MonoBehaviour
    {
        public static ShowMessage msg;
        public GameObject panel;

        private void Awake()
        {
            if (!msg) msg = this;
            else Destroy(this);
        }


        public void ShowMsg(string text)
        {
            panel.GetComponent<Text>().text = text;
            panel.GetComponent<Animation>().Play();
        }
    }
}