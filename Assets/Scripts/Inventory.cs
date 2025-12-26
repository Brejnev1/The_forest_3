using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField] private List<AssetItem> Items;
   [SerializeField] private InventoryCell inventoryCellTemplate;
	[SerializeField] private Transform container;

	public void OnEnable()
	{
		Render(Items);
	}
	
	public void Render(List<AssetItem> items)
	{
		foreach(Transform child in container)
			Destroy(child.gameObject);
		
		items.ForEach(item =>
		{
			var cell = Instantiate(inventoryCellTemplate, container);
			cell.Render(item);
		});
	}
}
