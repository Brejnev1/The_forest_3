using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
	[SerializeField] private TextMeshProUGUI nameField;
	[SerializeField] private Image iconField;

	private Transform _draggingParent;

	private Transform originalParent;


    public void Init(Transform draggingParent)
	{
		_draggingParent = draggingParent;
		originalParent = transform.parent;
	}

	public void Render(IItem item)
	{
		nameField.text = item.Name;
		iconField.sprite = item.UIIcon;
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		int closestIndex = 0;

        for (int i = 0; i < originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, originalParent.GetChild(i).position) <
                Vector3.Distance(transform.position, originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }

		transform.parent = originalParent;
		transform.SetSiblingIndex(closestIndex);
    }
}
