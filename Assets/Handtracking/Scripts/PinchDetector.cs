using UnityEngine;

public class PinchDetector : MonoBehaviour
{
    public static PinchDetector Instance;

    public float pinchThreshold = 0.025f;

    public bool IsPinching { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (HandDetection.Instance == null)
            return;

        float distance =
            Vector3.Distance(
                HandDetection.Instance.IndexFingerTip,
                HandDetection.Instance.ThumbTip);

        IsPinching = distance < pinchThreshold;

        if (InstructionOverlay.Instance != null)
        {
            InstructionOverlay.Instance.ShowInstruction(
                AssemblyManager.Instance.CurrentStep.stepNumber,
                AssemblyManager.Instance.CurrentStep.title,
                IsPinching ? " Pinching" : " Open Hand"
            );
        }
    }
}