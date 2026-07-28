using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    private Renderer[] renderers;

    [SerializeField]
    private Color highlightColor = Color.yellow;

    private Color[] originalColors;

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>(true);

        originalColors = new Color[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }

    public void Highlight()
    {
        foreach (var r in renderers)
        {
            r.material.color = highlightColor;
        }
    }

    public void RemoveHighlight()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }
    }

    //void Start()
    //{
    //    Highlight();
    //}
}