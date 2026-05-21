using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isOn;
    [SerializeField] private UnityEvent OnturnOn;
    [SerializeField] private UnityEvent OnturnOff;
    private Outline _Outline;
    private void Start()
    {
        _Outline = GetComponentInChildren<Outline>();
        _Outline.enabled = false;
    }
    public void ShowOutline()
    {
        if (_Outline != null)
        {
            _Outline.enabled = true;
        }
    }

    public void HideOutline()
    {
        if (_Outline != null)
        {
            _Outline.enabled = false;
        }
    }

    public void Interact()
    {
        if (_isOn)
        {
            OnturnOff.Invoke();
        }
        else
        {
            OnturnOn.Invoke();
        }
        _isOn = !_isOn;
        //Animação do interruptor mudando o botão
    }


}