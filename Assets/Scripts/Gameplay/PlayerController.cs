using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private LayerMask _interactionLayer;
    
    private Vector2 _direction;
    private Interactable _currentInteractable;
    private void FixedUpdate()
    {
        _rb.linearVelocity = _direction * _moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (_currentInteractable == null) return;
        
        _currentInteractable.Interact();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_interactionLayer & (1 << other.gameObject.layer)) != 0 )
        {
            Interactable interactable = other.GetComponentInParent<Interactable>();
            _currentInteractable = interactable;
            interactable.SetInteractable(true);                
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((_interactionLayer & (1 << other.gameObject.layer)) != 0 )
        {
            Interactable interactable = other.GetComponentInParent<Interactable>();
            if(_currentInteractable == interactable)
                _currentInteractable = null;
            interactable.SetInteractable(false);                
        }    
    }

}
