using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference clickInputActionReference;
    
    private InputAction _clickInput;
    
    private void Start()
    {
        _clickInput = clickInputActionReference.action;
        _clickInput.started += ctx => Click();
    }

    private void Click()
    {
        var t = transform;
        var hits  = Physics.RaycastAll(t.position, t.forward, 500.0F);
        
        foreach (var hit in hits)
        {
            UIButton button = hit.collider.gameObject.GetComponent<UIButton>();
            if (button != null)
            {
                button.SwitchScene();
            }
        }
    }
}
