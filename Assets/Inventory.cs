using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
       
        private List<string> inventory = new List<string>();

       
        public Text inventoryText;  
        public Text messageText;    
        public InputField itemInput;
        public Button addButton;    
        public Button removeButton;
       

        void Start()
        {
            
            addButton.onClick.AddListener(AddItem);
            removeButton.onClick.AddListener(RemoveItem);
            

          
            ViewInventory();
            ClearMessage();
        }

        
        void ViewInventory()
        {
            ClearMessage();
            inventoryText.text = "=== INVENTORY ===\n";
            for (int i = 0; i < inventory.Count; i++)
            {
                inventoryText.text += $"{i + 1}. {inventory[i]}\n";
            }
        }

        
        void AddItem()
        {
            string item = itemInput.text.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
                messageText.text = $"Item '{item}' added to inventory.";
                itemInput.text = "";
                ViewInventory();
            }
            else
            {
                messageText.text = "Please enter an item name to add.";
            }
        }

       
        void RemoveItem()
        {
            string item = itemInput.text.Trim();
            if (string.IsNullOrEmpty(item))
            {
                messageText.text = "Please enter an item name to remove.";
                return;
            }
            
            if (inventory.Remove(item))
            {
                messageText.text = $"Item '{item}' removed from inventory.";
                ViewInventory();
            }
            else
            {
                messageText.text = $"Item '{item}' not found in the inventory.";
            }
            itemInput.text = "";
        }

      
        void ClearMessage()
        {
            messageText.text = "";
        }
    }
}
