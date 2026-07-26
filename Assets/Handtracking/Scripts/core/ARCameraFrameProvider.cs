using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARCameraManager))]
public class ARCameraFrameProvider : MonoBehaviour
{
    public Texture2D CameraTexture { get; private set; }

    private ARCameraManager cameraManager;

    void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();
    }

    void OnEnable()
    {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        UpdateCameraTexture();
    }

    void UpdateCameraTexture()
    {
        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
            return;

        var conversionParams = new XRCpuImage.ConversionParams
        {
            inputRect = new RectInt(0, 0, image.width, image.height),
            outputDimensions = new Vector2Int(image.width, image.height),
            outputFormat = TextureFormat.RGBA32,
            transformation = XRCpuImage.Transformation.MirrorY
        };

        if (CameraTexture == null ||
            CameraTexture.width != image.width ||
            CameraTexture.height != image.height)
        {
            CameraTexture = new Texture2D(
                image.width,
                image.height,
                TextureFormat.RGBA32,
                false);
        }

        var rawTexture = CameraTexture.GetRawTextureData<byte>();

        image.Convert(conversionParams, rawTexture);

        CameraTexture.Apply(false);

        image.Dispose();
    }
}