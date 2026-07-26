//using Unity.Collections;
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

//[RequireComponent(typeof(ARCameraManager))]
//public class ARCameraTextureProvider : MonoBehaviour
//{
//    public Texture2D CameraTexture { get; private set; }


//    private ARCameraManager cameraManager;

//    void Awake()
//    {
//        cameraManager = GetComponent<ARCameraManager>();
//    }

//    void Update()
//    {
//        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
//            return;

//        var conversionParams = new XRCpuImage.ConversionParams
//        {
//            inputRect = new RectInt(0, 0, image.width, image.height),
//            outputDimensions = new Vector2Int(image.width, image.height),
//            outputFormat = TextureFormat.RGBA32,
//            transformation = XRCpuImage.Transformation.MirrorY

//        };

//        if (CameraTexture == null ||
//            CameraTexture.width != image.width ||
//            CameraTexture.height != image.height)
//        {
//            CameraTexture = new Texture2D(
//                image.width,
//                image.height,
//                TextureFormat.RGBA32,
//                false);
//        }

//        var rawTextureData = CameraTexture.GetRawTextureData<byte>();

//        // SAFE overload (no unsafe pointers)
//        image.Convert(conversionParams, rawTextureData);
//        CameraTexture.Apply(false);

//        Debug.Log("Camera Updated: " + image.width + " x " + image.height);

//        image.Dispose();
//    }
//}

using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARCameraManager))]
public class ARCameraTextureProvider : MonoBehaviour
{
    public Texture2D CameraTexture { get; private set; }

    private ARCameraManager cameraManager;

    void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();
    }

    void OnDisable()
    {
        if (CameraTexture != null)
        {
            Destroy(CameraTexture);
            CameraTexture = null;
        }
    }

    void Update()
    {
        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
            return;

        // Determine correct CPU Image transformation based on screen / camera orientation
        // Default to MirrorY or None based on platform testing, but avoid hardcoding static flips blindly
        XRCpuImage.Transformation imageTransformation = XRCpuImage.Transformation.MirrorY;

        // Re-instantiate texture if size changed
        if (CameraTexture == null ||
            CameraTexture.width != image.width ||
            CameraTexture.height != image.height)
        {
            if (CameraTexture != null) Destroy(CameraTexture);

            CameraTexture = new Texture2D(
                image.width,
                image.height,
                TextureFormat.RGBA32,
                false);
        }

        var conversionParams = new XRCpuImage.ConversionParams
        {
            inputRect = new RectInt(0, 0, image.width, image.height),
            outputDimensions = new Vector2Int(image.width, image.height),
            outputFormat = TextureFormat.RGBA32,
            transformation = imageTransformation
        };

        // Efficient conversion without allocating new wrapper arrays each frame
        var rawTextureData = CameraTexture.GetRawTextureData<byte>();
        image.Convert(conversionParams, rawTextureData);
        CameraTexture.Apply(false);

        image.Dispose();
    }
}