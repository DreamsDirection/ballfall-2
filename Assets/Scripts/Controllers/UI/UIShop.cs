
using System.Collections;
using System.Collections.Generic;
using Controllers.UI;
using Items;
using Items.Controller;
using Items.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UIShop : UIBase
    {
        public GameObject ShopCell;
        public GameObject ShopGrid;
        public Text TextScore;
        public SOHolder soHolder;


        private List<Cell> L_Cells = new List<Cell>();
        private ItemsHolder holder = new ItemsHolder();

        private void Start()
        {
            holder.Init(soHolder.Items);
            ClearCells();
            SetupCells();
        }
        
        public override void Open()
        {
            TextScore.text = GC.Score.ToString();
        }

        public override void Close()
        {
            
        }


        void ClearCells()
        {
            
        }

        void SetupCells()
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
                cell.Init(item.image,item.Price.ToString(),() => {ButtonClick(id);});
                //
                cell.name = "Cell_" + id;
                L_Cells.Add(cell);
            }
        }


        void ButtonClick(int id)
        {
            Item item = holder.GetItem(id);
            Cell cell = L_Cells[id].GetComponent<Cell>();

            if (item.IsBuy)
            {
                Debug.Log("Select-" + id);
                for (int i = 0; i < L_Cells.Count; i++)
                    L_Cells[i].UnSelect();
                cell.Select();
                GC.Ball.GetComponent<SpriteRenderer>().sprite = item.image;
            }
            else
            {
                Debug.Log("Buy- " + id);
                if (GC.Score >= item.Price)
                {
                    cell.Buy();
                    item.IsBuy = true;
                    GC.Score -= item.Price;
                }
            }
            TextScore.text = GC.Score.ToString();

        }

        public bool CanBuy()
        {
            int count = holder.ItemsCount;
            float money = GC.Score;
            float bonus = GC.GameScore;
            for (int i = 0; i < count; i++)
            {
                Item item = holder.GetItem(i);
                if (item.Price <= money + bonus && !item.IsBuy) return true;
            }

            return false;
        }

        public void Return()
        {
            UIController.UI.ShowUI<UIMainMenu>();
        }
    }
}