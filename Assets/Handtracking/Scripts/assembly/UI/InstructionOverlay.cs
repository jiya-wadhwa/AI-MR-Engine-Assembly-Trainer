using TMPro;
using UnityEngine;

public class InstructionOverlay : MonoBehaviour
{
    public static InstructionOverlay Instance;

    public TMP_Text stepText;
    public TMP_Text titleText;
    public TMP_Text statusText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowInstruction(int step, string title, string status)
    {
        stepText.text = $"STEP {step}";
        titleText.text = title;
        statusText.text = status;
    }

    public void UpdateStatus(string status)
    {
        statusText.text = status;
    }

    public void ShowSuccess(string message)
    {
        statusText.text = "✓ " + message;
    }

    public void ShowError(string message)
    {
        statusText.text = "✗ " + message;
    }
}