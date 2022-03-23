using UnityEngine;

public class ResourcePackData : MonoBehaviour
{
    [SerializeField] private ResourcePackConfig _config;

    public string Name => _config.Name;
    public int SellPrice => _config.SellPrice;
}
