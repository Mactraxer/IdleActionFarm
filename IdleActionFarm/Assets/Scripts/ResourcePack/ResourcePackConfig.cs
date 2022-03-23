using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePack", menuName = "ScriptableObjects/New Resource Pack")]
public class ResourcePackConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _sellPrice;

    public string Name => _name;
    public int SellPrice => _sellPrice;
}
