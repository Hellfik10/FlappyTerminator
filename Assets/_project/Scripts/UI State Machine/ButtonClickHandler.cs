using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickButton); 
    }

    private void ClickButton()
    {
        ButtonClicked?.Invoke();
    }

}
