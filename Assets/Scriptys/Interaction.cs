using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2.5f;
    private Camera _mainCam;
    private RaycastHit _target; //Objeto alvo do raycast

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out _target, _interactionDistance))
            return;
        // O raycast bateu em algo
    }

    public void OnInteract()
    {
        if(_target.collider == null) //NullCheck, para evitar erros
            return;
        if (!_target.collider.TryGetComponent(out IInteractable interactable))
            return;

        interactable.Interact();
    }


}
