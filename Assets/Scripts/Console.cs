using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    [SerializeField] private GameObject consolePanel;
    [SerializeField] private TMP_InputField consoleInput;
    [SerializeField] private GameManager gameManager;

    private InputSystem_Actions inputSystem;
    private InputAction console;
    private bool isVisible;

    void Awake()
    {
        inputSystem = new InputSystem_Actions();
        console = inputSystem.UI.Console;
        
        console.performed += ToggleConsole;
    }

    void Start()
    {
        if (consolePanel != null)
        {
            consolePanel.SetActive(false);
        }
        
        consoleInput.onSubmit.AddListener(OnSubmitCommand);
    }

    void OnEnable()
    {
        inputSystem.Enable();
    }

    void OnDisable()
    {
        inputSystem.Disable();
    }
    
    private void ToggleConsole(InputAction.CallbackContext context)
    {
        if (consoleInput.isFocused) return;
        
        isVisible = !isVisible;
        consolePanel.SetActive(isVisible);

        if (isVisible)
        {
            consoleInput.text = "";
            consoleInput.ActivateInputField();
        }
        
        Time.timeScale = isVisible ? 0 : 1;
    }

    private void OnSubmitCommand(string input)
    {
        if (string.IsNullOrEmpty(input)) return;

        switch (input)
        {
            case "P1Point":
                gameManager.Player1Scored();
                break;
            case "P2Point": 
                gameManager.Player2Scored();
                break;
            case "Reset":
                gameManager.Reset();
                break;
            case "AIActive":
                gameManager.SetAIActive(true);
                break;
            case "NoAI":
                gameManager.SetAIActive(false);
                break;
        }
    }
}
