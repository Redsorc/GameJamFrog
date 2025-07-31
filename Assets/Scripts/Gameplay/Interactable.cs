using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnInteract;
    [SerializeField] private Canvas _canvas;
    private bool _interactable = false;
    
    public void Interact()
    {
        if (!_interactable) return;
        Debug.Log("Interact");
        OnInteract.Invoke();
    }

    public void SetInteractable(bool value)
    {
        if (_interactable == value) return;
        
        _interactable = value;
        
        _canvas.enabled = _interactable;
    }
}
