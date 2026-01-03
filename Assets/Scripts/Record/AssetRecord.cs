using System.Collections;
using UnityEngine;

public class AssetRecord : MonoBehaviour, IItem
{
    public string Name => name;
    public Sprite UIIcon => uiIcon;

    [SerializeField] private string name;
    [SerializeField] private Sprite uiIcon;
    public AudioClip Track;
}
