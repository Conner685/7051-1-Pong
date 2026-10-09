using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne;
    
    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private float paddleSpeed;
    
    private InputSystem_Actions _inputSystem;
    private InputAction _curMovement;
    void Awake()
    {
        if (_inputSystem != null)
        {
            return;
        }
        
        _inputSystem = new InputSystem_Actions();
        
        _curMovement = (isPlayerOne) ? _inputSystem.Player.PlayerMove : _inputSystem.Player.PlayerMove2;
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void OnDestroy()
    {
        _inputSystem.Dispose();
    }

    void FixedUpdate()
    {
        Vector3 input = _curMovement.ReadValue<Vector2>();

        input.z = input.y;
        input.y = 0;
        
        rb.AddForce(paddleSpeed * input);
        if (Mathf.Abs(rb.linearVelocity.z) > paddleSpeed)
        {
            rb.linearVelocity =  paddleSpeed * input;
        }
    }
}
