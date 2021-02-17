using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace DLTool
{

    public class DlCase2p3Runner : MonoBehaviour
    {
        private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;
        private bool mAccessCameraImage = true;
        private bool mFormatRegistered = false;

        private int ORIGINAL_WIDTH;
        private int ORIGINAL_HEIGHT;
        public const int IMAGE_WIDTH = 256;
        public const int IMAGE_HEIGHT = 320;

        public static Camera cam;

        public int speed;

        int counter = 0;

        //game object storing dl
        public GameObject dl;
        public float yAdjustValue;

        public bool runnerDone = false;     // var to check deeplearning done or not
        private bool isDone = false;

        public Texture2D textureMap;

        public List<Vector3> a;

        void Start()
        {
            // set candidate pixel format
            mPixelFormat = PIXEL_FORMAT.RGBA8888;
            // Register Vuforia life-cycle callbacks:
            VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
            cam = Camera.main;
        }

        void OnVuforiaStarted()
        {
            // set image format
            if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
            {
                Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
                mFormatRegistered = true;
            }
            else
            {
                // point addressing the problem
                Debug.LogError(
                    "\nFailed to register pixel format: " + mPixelFormat.ToString() +
                    "\nThe format may be unsupported by your device." +
                    "\nConsider using a different pixel format.\n");
                mFormatRegistered = false;
            }
        }

        void Update()
        {
            if (isDone)
            {
                runnerDone = true;      // deeplearning done

                if (counter < a.Count)
                {
                    float newY = a[counter].y* yAdjustValue;

                    dl.transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                }
                else
                {
                    counter = 0;
                }
            }
        }

        public void OnTrackablesUpdated()
        {
            if (mFormatRegistered)
            {
                if (mAccessCameraImage)
                {
                    Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                    ORIGINAL_WIDTH = image.Width;
                    ORIGINAL_HEIGHT = image.Height;
                    if (image != null)
                    {
                        if (counter == 100)
                        {
                            //initial codes is:
                            Texture2D texture = new Texture2D(image.Width, image.Height, TextureFormat.RGBA32, false);

                            image.CopyToTexture(texture);
                            texture = ImageTool.ScaleTexture(texture, IMAGE_WIDTH, IMAGE_HEIGHT);

                            //initial code is:
                            //Color32[] pixels = texture.GetPixels32();
                            Color32[] pixels = texture.GetPixels32();

                            Detection model = new Detection();
                            Texture2D result = model.Segmentation(pixels);
 
                            result = ImageTool.ScaleTexture(result, ORIGINAL_WIDTH, ORIGINAL_HEIGHT);
                            Dictionary<int, int> line = ImageTool.GetLine(result, 'x', 2.3f);

                            // StreamWriter writer1 = new StreamWriter("./indices.txt", true);
                            List<Vector3> WorldPoints = ImageTool.GetWorldPoints(line);

                            this.a = WorldPoints;

                            mAccessCameraImage = false;
                            isDone = true;
                        }
                        else
                        {
                            counter += 1;
                        }
                    }
                }
            }
        }
    }
}
