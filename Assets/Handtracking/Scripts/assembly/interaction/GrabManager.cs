using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public static GrabManager Instance;

    [Header("Grab Settings")]
    [SerializeField] private float grabOffset = 0.05f;

    private PartInteractable grabbedPart;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

        if (PinchDetector.Instance.IsPinching &&
    SelectionManager.Instance.CurrentSelectedPart != null)
        {
            InstructionOverlay.Instance.UpdateStatus("Trying Grab");
            GrabPart();
        }





        // Safety checks
        if (HandDetection.Instance == null ||
            PinchDetector.Instance == null ||
            SelectionManager.Instance == null)
            return;

        // Already grabbing
        if (grabbedPart != null)
        {
            if (PinchDetector.Instance.IsPinching)
            {
                MovePart();
            }
            else
            {
                ReleasePart();
            }

            return;
        }

        // Start grab
        if (PinchDetector.Instance.IsPinching &&
            SelectionManager.Instance.CurrentSelectedPart != null)
        {
            GrabPart();
        }
    }

    private void GrabPart()
    {



        InstructionOverlay.Instance.UpdateStatus("GrabPart Called");


        grabbedPart = SelectionManager.Instance.CurrentSelectedPart;

        if (grabbedPart == null)
            return;

        InstructionOverlay.Instance.UpdateStatus("Selected = " + grabbedPart.name);

        grabbedPart.IsGrabbed = true;

        InstructionOverlay.Instance.UpdateStatus("Grabbed " + grabbedPart.name);

    }

    private void MovePart()
    {
        InstructionOverlay.Instance.UpdateStatus("Moving");

        Vector3 targetPosition =
            HandDetection.Instance.IndexFingerTip +
            Camera.main.transform.forward * grabOffset;

        grabbedPart.transform.position = targetPosition;
    }

    private void ReleasePart()
    {
        if (grabbedPart == null)
            return;

        grabbedPart.IsGrabbed = false;

        Debug.Log("Released: " + grabbedPart.name);

        grabbedPart = null;
    }

    public PartInteractable GetGrabbedPart()
    {
        return grabbedPart;
    }
}
