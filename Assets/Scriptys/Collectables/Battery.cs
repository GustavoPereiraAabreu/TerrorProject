using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]

public class Battery : MonoBehaviour, ICollectable
{
    private Outline _outline;

    public void Collect()
    {
       Destroy(gameObject); // Destroi o objeto da bateria quando coletada
    }

    public void HideOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = false; // Desativa o contorno quando não for mirado
        }
    }

    public void ShowOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = true;// Ativa o contorno quando for mirado
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

}
