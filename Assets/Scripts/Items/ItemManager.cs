using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using Pink.Events;
using static Pink.Environment.Simulation;

namespace Pink.Items {
    public class ItemManager : MonoBehaviour
    {

        [Tooltip("All items within a scene")]
        public ItemController[] items;

        public bool AllCollected 
        {
            get {
                return CollectedItemCount == items.Length;
            }
        }

        public IEnumerable<ItemController> CollectedItems
        {
            get {
                return items.Where(i => i.isCollected);
            }
        }

        public int CollectedItemCount
        {
            get {
                return CollectedItems.Count();
            }
        }

        [ContextMenu("Find All Tokens")]
        public void FindAllItems()
        {
            items = UnityEngine.Object.FindObjectsOfType<ItemController>();

            foreach(var item in items)
            {
                item.manager = this;
            }
        }

        //Maybe should be start
        void Awake()
        {
            if (items.Length == 0)
                FindAllItems();
        }

        public void ResetItems()
        {
            foreach(var item in CollectedItems)
            {
                item.Reset();
            }
        }

        public void ItemCollected(ItemController item)
        {
            if(AllCollected)
            {
                Schedule<LevelWin>();
            }
        }
    }
}