using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Tools", menuName = "Tool")]
public class EquipmentObject : ScriptableObject
{
    public string toolsName;
    public Sprite icon;
}
