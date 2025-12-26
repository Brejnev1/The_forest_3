using System;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, IItem
{
	public string Name => name;
	public Sprite UIIcon => uiIcon;
	
	[SerializeField] private string name;
	[SerializeField] private Sprite uiIcon;
}
