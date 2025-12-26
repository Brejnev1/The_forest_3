using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI nameField;
	[SerializeField] private Image iconField;
	
	public void Render(IItem item)
	{
		nameField.text = item.Name;
		iconField.sprite = item.UIIcon;
	}
}
