
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();

    }

    void PickUp()
    {

        
        Debug.Log("Picking up item" + item.name);

        //인벤토리에 추가
        //FindObjectOfType<Inventory>().Add
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }

}
