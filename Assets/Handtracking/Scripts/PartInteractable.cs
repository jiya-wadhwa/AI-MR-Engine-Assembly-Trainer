using UnityEngine;

public class PartInteractable : MonoBehaviour
{
    [Header("Part Information")]
    public PartType partType = PartType.None;

    public int partID;
    public bool IsGrabbed { get; set; }

    public string partName;

    public int assemblyOrder;

    [HideInInspector]
    public bool isGrabbed;

    [HideInInspector]
    public bool isAssembled;

    private Renderer cachedRenderer;

    void Awake()
    {
        cachedRenderer = GetComponent<Renderer>();
    }

    public Renderer GetRenderer()
    {
        return cachedRenderer;
    }
}