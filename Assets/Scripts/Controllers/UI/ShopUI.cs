
using System.Collections.Generic;
using BallFall.UI;
using Items.Controller;
using Items.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BallFall.Controllers.UI
{
    public class ShopUI : MonoBehaviour
    {
        GameController GC => GameController.GC;
        
        
        public ItemsHolder holder;
        public GameObject ShopCell;
        public GameObject ShopGrid;
        private List<GameObject> L_Cells = new List<GameObject>();

        private void Start()
        {
            ClearCells();
            SetupCells();
        }

        void ClearCells()
        {
            
        }

        public void SetupCells()
        {
            int count = holder.ItemsCount;
            for (int i = 0; i < count; i++)
            {
                GameObject goCell = Instantiate(ShopCell, ShopGrid.transform);
                Item item = holder.GetItem(i);
                Cell cell = goCell.GetComponent<Cell>();
                
                // Не пытаться поменять ButtonClick(id) на ButtonClick(i)
                //Это приведёт к одному и тому же числу во всех кнопках
                var id = i;
                cell.Button.onClick.AddListener(() => {ButtonClick(id);} );
                //
                
                cell.img.sprite = item.image;
                cell.txt.text = item.Price.ToString();
                
                L_Cells.Add(goCell);
            }
        }


        public void ButtonClick(int id)
        {
            Item item = holder.GetItem(id);
            Cell cell = L_Cells[id].GetComponent<Cell>();

            if (item.IsBuy)
            {
                cell.Button.interactable = false;
                for (int i = 0; i < L_Cells.Count; i++)
                    L_Cells[i].GetComponent<Cell>().Button.interactable = true;
                GC.Ball.GetComponent<Image>().sprite = item.image;
            }
            else
            {
                if (GC.Score >= item.Price)
                {
                    cell.txt.text = "";
                    cell.imgBlock.enabled = false;
                    item.IsBuy = true;
                    GC.Score -= item.Price;
                }
            }

        }

        public bool CanBuy()
        {
            int count = holder.ItemsCount;
            float money = GC.Score;
            for (int i = 0; i < count; i++)
                if (holder.GetItem(i).Price <= money) return true;

            return false;
        }
    }
}