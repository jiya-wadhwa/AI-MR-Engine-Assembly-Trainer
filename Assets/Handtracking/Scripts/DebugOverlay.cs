using UnityEngine;
using TMPro;

public class DebugOverlay : MonoBehaviour
{
    public static DebugOverlay Instance;

    public TMP_Text debugText;

    void Awake()
    {
        Instance = this;
    }

    public void SetText(string text)
    {
        if (debugText != null)
            debugText.text = text;
    }
}