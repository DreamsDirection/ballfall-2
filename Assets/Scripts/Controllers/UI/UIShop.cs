
using System;
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
        private ItemsHolder holder;

        private void Start()
        {
            holder = new ItemsHolder(soHolder);
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
            bool SelectedFind = false;
            for (int i = 0; i < count; i++)
            {
                GameObject goCell = Instantiate(ShopCell, ShopGrid.transform);
                SOItem item = holder.GetItem(i);
                Cell cell = goCell.GetComponent<Cell>();

                // Не пытаться поменять ButtonClick(id) на ButtonClick(i)
                //Это приведёт к одному и тому же числу во всех кнопках
                var id = i;
                cell.Init(item.Image, item.Price.ToString(), () => { ButtonClick(id); });
                //
                cell.name = "Cell_" + id;

                L_Cells.Add(cell);

                Item it = holder.Items[id];
                if (it.IsBuy) cell.Buy();
                if (it.IsSelected)
                {
                    Select(id);
                    SelectedFind = true;
                }
            }

            L_Cells[0].Buy();
            if (!SelectedFind)
            {
                Buy(0);
                Select(0);
            }
        }


        void ButtonClick(int id)
        {
            Item item = holder.Items[id];
            SOItem SOItem = holder.GetItem(id);
            Cell cell = L_Cells[id].GetComponent<Cell>();

            if (item.IsBuy)
            {
                Select(id);
            }
            else
            {
                Buy(id);
            }

            TextScore.text = GC.Score.ToString();
            holder.Save();
        }

        void Select(int id)
        {
            Item item = holder.Items[id];
            SOItem SOItem = holder.GetItem(id);
            Cell cell = L_Cells[id].GetComponent<Cell>();
            
            Debug.Log("Select-" + id);
            for (int i = 0; i < L_Cells.Count; i++)
            {
                L_Cells[i].UnSelect();
                holder.Items[i].IsSelected = false;
            }
            cell.Select();
            item.IsSelected = true;
            GC.Ball.GetComponent<SpriteRenderer>().sprite = SOItem.Image;
            holder.Save();
        }

        void Buy(int id)
        {
            Item item = holder.Items[id];
            SOItem SOItem = holder.GetItem(id);
            Cell cell = L_Cells[id].GetComponent<Cell>();
            
            Debug.Log("Buy- " + id);
            if (GC.Score >= SOItem.Price)
            {
                cell.Buy();
                item.IsBuy = true;
                GC.Score -= SOItem.Price;
            }
        }

        public bool CanBuy()
        {
            try
            {
                int count = holder.ItemsCount;
                float money = GC.Score;
                float bonus = GC.GameScore;
                for (int i = 0; i < count; i++)
                {
                    SOItem item = holder.GetItem(i);
                    Item _item = holder.Items[i];
                    if (item.Price <= money + bonus && !_item.IsBuy) return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return false;
            }
        }

        public void Return()
        {
            UIController.UI.ShowUI<UIMainMenu>();
            holder.Save();
        }
    }
}