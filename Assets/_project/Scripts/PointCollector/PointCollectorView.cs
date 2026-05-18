using UnityEngine;
using TMPro;

public class PointCollectorView : MonoBehaviour
{
    [SerializeField] private PointCollector _pointCollector;
    [SerializeField] private TMP_Text _text;

    private float startPointsValue = 0;

    private void OnEnable()
    {
        _text.text = startPointsValue.ToString();
        _pointCollector.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _pointCollector.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(float value)
    {
        _text.text = value.ToString();
    }
}
