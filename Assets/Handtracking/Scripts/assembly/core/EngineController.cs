using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour
{
    public List<PartInteractable> parts = new();

    void Awake()
    {
        parts.AddRange(GetComponentsInChildren<PartInteractable>());

        Debug.Log($"Engine Loaded : {parts.Count} interactive parts");

        foreach (var part in parts)
        {
            Debug.Log($"{part.partType} : {part.name}");
        }
    }
}