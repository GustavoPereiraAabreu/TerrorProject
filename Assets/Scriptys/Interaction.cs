using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2.5f;
    private Camera _mainCam;
    private IInteractable _target; //Objeto alvo do raycast

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out RaycastHit hit, _interactionDistance))
        {
            // O raycast bateu em algo

            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (_target == interactable)
                    return;
                _target = interactable;
                _target.ShowOutline();
            }

            else
            {
                _target?.HideOutline();
                _target = null;
            }
        }
        else
        {
            _target?.HideOutline();
            _target = null;
        }

    }

    public void OnInteract(InputValue value)
    {
        if (_target == null)//nullcheck
            return;

       _target.Interact();
    }

}
