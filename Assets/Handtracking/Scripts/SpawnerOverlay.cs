using TMPro;
using UnityEngine;

public class SpawnerOverlay : MonoBehaviour
{
    public static SpawnerOverlay Instance;

    [SerializeField] private TMP_Text debugText;

    void Awake()
    {
        Instance = this;
    }

    public void SetText(string message)
    {
        if (debugText != null)
            debugText.text = message;
    }
}