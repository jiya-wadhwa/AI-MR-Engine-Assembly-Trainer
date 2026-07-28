using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleController : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public Camera arCamera;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        Vector2 screenCenter =
            new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            transform.position = hitPose.position;
            transform.rotation =
                Quaternion.Euler(
                    0,
                    arCamera.transform.eulerAngles.y,
                    0);

            gameObject.SetActive(true);

            if (DebugOverlay.Instance != null)
            {
                DebugOverlay.Instance.SetText(
                    $"Plane : YES\n" +
                    $"Hits : {hits.Count}\n" +
                    $"X : {hitPose.position.x:F2}\n" +
                    $"Y : {hitPose.position.y:F2}\n" +
                    $"Z : {hitPose.position.z:F2}"
                );
            }
        }
        else
        {
            // Reticle visible hi rakhenge abhi debugging ke liye
            gameObject.SetActive(true);

            if (DebugOverlay.Instance != null)
            {
                DebugOverlay.Instance.SetText(
                    "Plane : NO"
                );
            }
        }
    }
}