using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isOn;
    [SerializeField] private UnityEvent OnTurnOn;
    [SerializeField] private UnityEvent OnTurnOff;

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
    void Start()
    {
        
    }


}
