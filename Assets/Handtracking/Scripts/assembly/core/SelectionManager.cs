using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public float detectionRadius = 0.03f;
    public static SelectionManager Instance;

    public PartInteractable CurrentSelectedPart
    {
        get;
        private set;
    }
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (HandDetection.Instance == null)
            return;

        if (AssemblyManager.Instance == null)
            return;

        Vector3 finger = HandDetection.Instance.IndexFingerTip;

        Collider[] hits = Physics.OverlapSphere(
            finger,
            detectionRadius);

        PartInteractable nearest = null;

        foreach (Collider hit in hits)
        {
            PartInteractable part = hit.GetComponent<PartInteractable>();

            if (part == null)
                continue;

            // Only allow the required part for the current assembly step
            if (part.partType != AssemblyManager.Instance.GetRequiredPart())
                continue;

            nearest = part;
            break;
        }

        if (nearest == CurrentSelectedPart)
            return;

        if (CurrentSelectedPart != null)
            CurrentSelectedPart.GetComponent<HighlightManager>()?.RemoveHighlight();

        CurrentSelectedPart = nearest;

        if (CurrentSelectedPart != null)
        {
            CurrentSelectedPart.GetComponent<HighlightManager>()?.Highlight();
        }
    }
}