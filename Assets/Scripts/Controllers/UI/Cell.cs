
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class Cell : MonoBehaviour
    {
        [SerializeField]private Button button;
        [SerializeField]private Image ballImage;
        [SerializeField]private Image imageCellLock;
        [SerializeField]private Image cellImage;
        [SerializeField]private Text txt;


        [SerializeField]private Sprite cellSprite;
        [SerializeField]private Sprite cellActiveSprite;

        public void Init(Sprite img, string price,UnityAction listener)
        {
            button.onClick.AddListener(listener);
            ballImage.sprite = img;
            txt.text = price;
            imageCellLock.enabled = true;
        }
        public void Buy()
        {
            imageCellLock.enabled = false;
            txt.text = "";
        }

        public void Select()
        {
            Debug.Log("SelectMethod");
            button.interactable = false;
            cellImage.sprite = cellActiveSprite;
        }

        public void UnSelect()
        {
            button.interactable = true;
            cellImage.sprite = cellSprite;
        }
    }
}