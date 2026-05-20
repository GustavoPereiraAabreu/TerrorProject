using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isOn;
    [SerializeField] private UnityEvent OnTurnOn;
    [SerializeField] private UnityEvent OnTurnOff;
    private Outline _outline;

    private void Start()
    {
        _outline = GetComponentInChildren<Outline>();
    }

    public void HideOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }

    public void Interact()
    {
        if(_isOn)
        {
            OnTurnOff.Invoke();
        }
        else
        {
            OnTurnOn.Invoke();
        }
        _isOn = !_isOn;
        //Animação do interruptor, ligar e desligar
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ShowOutline()
    {
        if (_outline != null)
        {
             _outline.enabled = true;
        }
    }

}
