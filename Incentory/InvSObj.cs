using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Eat, Gun, Craftitem, Clothes }
[CreateAssetMenu(fileName="GunItem",menuName = "Inventory/Items/New Gun Item")]
public class InvSObj : ScriptableObject
{
    public string NameItem;
    public int MaxStak;
    public GameObject ItemPrefab;
    public GameObject InstPrefab;
    public Sprite icon;
}
