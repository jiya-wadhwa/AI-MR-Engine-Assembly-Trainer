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
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            transform.position = hitPose.position;
            transform.rotation = Quaternion.Euler(0, arCamera.transform.eulerAngles.y, 0);

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}