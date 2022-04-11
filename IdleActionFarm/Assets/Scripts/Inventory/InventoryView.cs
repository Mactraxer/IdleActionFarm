using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InventoryView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _inventoryCapacityText;
    [SerializeField] private Slider _inventoryCapacitySlider;

    private int _maxCapacity;
    private int _currentCapacity;

    private void Start()
    {
        _currentCapacity = 0;
        _maxCapacity = 0;
    }

    public void SetupInventoryView(int maxCapacity)
    {
        _maxCapacity = maxCapacity;
        UpdateText();
    }

    public void UpdateInventoryView(int value)
    {
        _currentCapacity = value;
        UpdateSlider();
        UpdateText();
    }

    private void UpdateSlider()
    {
        _inventoryCapacitySlider.value = (float)_currentCapacity / (float)_maxCapacity;
    }

    private void UpdateText()
    {
        _inventoryCapacityText.text = $"{_currentCapacity}/{_maxCapacity}";
    }

}
