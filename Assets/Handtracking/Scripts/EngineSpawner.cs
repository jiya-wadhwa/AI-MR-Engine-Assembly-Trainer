using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class EngineSpawner : MonoBehaviour
{
    public GameObject enginePrefab;
    public ReticleController reticle;

    bool spawned = false;

    void Start()
    {
        EnhancedTouchSupport.Enable();
        SpawnerOverlay.Instance?.SetText("EngineSpawner Started");
    }

    void Update()
    {
        if (reticle == null || enginePrefab == null)
        {
            SpawnerOverlay.Instance?.SetText("Missing References");
            return;
        }

        if (spawned)
            return;

        var touches = Touch.activeTouches;

        SpawnerOverlay.Instance?.SetText($"Touches : {touches.Count}");

        if (touches.Count == 0)
            return;

        var touch = touches[0];

        if (!touch.began)
            return;

        SpawnerOverlay.Instance?.SetText("Touch Detected");

        GameObject obj = Instantiate(
            enginePrefab,
            reticle.transform.position,
            reticle.transform.rotation
        );

        obj.transform.localScale = Vector3.one * 0.1f;

        spawned = true;

        SpawnerOverlay.Instance?.SetText("Engine Spawned");
    }
    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}