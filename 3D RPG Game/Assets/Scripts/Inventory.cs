using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
		if (instance != null)
		{
			Debug.LogWarning("more than one instance of Inventory");
			return ;
		}
		instance = this;
    }

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;


	public int space = 2;

    public List<Item> items = new List<Item>();


	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("FULL INVENTORY");
				return false;
			}
			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();

			return true;
		}
		return false;
		
	}
	
	public void Remove(Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();

	}

}


// onItemChangedCallback += SHowUI;