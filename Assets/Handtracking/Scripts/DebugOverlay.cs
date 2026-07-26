using UnityEngine;
using TMPro;

public class DebugOverlay : MonoBehaviour
{
    public static DebugOverlay Instance;

    public TextMeshProUGUI debugText;

    void Awake()
    {
        Instance = this;
    }

    public void Log(string message)
    {
        Debug.Log(message);

        if (debugText != null)
            debugText.text = message;
    }
}