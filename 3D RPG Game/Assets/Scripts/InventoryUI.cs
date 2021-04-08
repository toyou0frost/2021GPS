
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemParent;

    public GameObject inventoryUI;
    
    InventorySlot[] slots;

    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            UpdateUI();
        }

        
    }

    void UpdateUI()
    {        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else 
            {
                slots[i].ClearSlot();
            }
        }

    }
}

