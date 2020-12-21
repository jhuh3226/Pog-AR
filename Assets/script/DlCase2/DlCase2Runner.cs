using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace DLTool {

    public class DlCase2Runner : MonoBehaviour
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

        Vector3 startPosition;
        Vector3 endPosition;
        int counter = 0;
        public GameObject car;
        public GameObject carPoint0;
        public GameObject carPoint1;
        public GameObject carPoint2;
        public GameObject carPoint3;
        public float carXAdjustValue;
        public float carYAdjustValue;

        public GameObject pogBot;
        public GameObject pogPoint0;
        public GameObject pogPoint1;
        public GameObject pogPoint2;
        public GameObject pogPoint3;
        public float pogXAdjustValue;
        public float pogYAdjustValue;
        public float pogZAdjustValue;

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
                    //float newX = a[counter].x - a[0].x + a[0].x + 3.0f;
                    //float newY = a[counter].y - a[0].y + a[0].y + 2.0f;

                    // original counter value is 5, substituted to 'speed'
                    //counter += speed;

                    //car.transform.position = new Vector3(newX, newY, a[counter].z);

                    // new setting for the Y position, where car is situated on right side(upper line)
                    float carNewX = a[a.Count - 1].x + carXAdjustValue;
                    float carNewY = a[counter].y + carYAdjustValue;

                    float carP0X = carNewX;
                    float carP1X = carNewX - (carNewX - a[0].x) * 1 / 3;
                    float carP2X = carNewX - (carNewX - a[0].x) * 2 / 3;
                    float carP3X = a[0].x;

                    // setting position of the car beizercarve
                    carPoint0.transform.position = new Vector3(carP0X, carNewY, a[counter].z);
                    carPoint1.transform.position = new Vector3(carP1X, carNewY, a[counter].z);
                    carPoint2.transform.position = new Vector3(carP2X, carNewY, a[counter].z);
                    carPoint3.transform.position = new Vector3(carP3X, carNewY, a[counter].z);

                    // console out
                    //Debug.Log("X position: " + newX);
                    //Debug.Log("Y position: " + newY);

                    Debug.Log("X length first: " + a[0].x);
                    Debug.Log("X length last: " + a[a.Count - 1].x);
                    Debug.Log("Y length first: " + a[0].y);
                    Debug.Log("Y length last: " + a[a.Count - 1].y);

                    float pogNewX = a[(a.Count - 1) / 2].x + pogXAdjustValue;
                    float pogNewY = a[(a.Count - 1) / 2].y + pogYAdjustValue;
                    float pogNewZ = a[(a.Count - 1) / 2].z + pogZAdjustValue;


                    // initial pogbot position is relative to the position oof newX and Y
                    pogBot.transform.localPosition = new Vector3(pogNewX, pogNewY, pogNewZ);
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
                    // Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
                    // ORIGINAL_WIDTH = image.Width;
                    // ORIGINAL_HEIGHT = image.Height;
                    // if (image != null)
                    // {
                        if (counter == 100)
                        {
                            //Texture2D texture = new Texture2D(image.Width, image.Height, TextureFormat.RGBA32, false);
                            //image.CopyToTexture(texture);
                            ORIGINAL_WIDTH = textureMap.width;
                            ORIGINAL_HEIGHT = textureMap.height;
                            Debug.Log(ORIGINAL_WIDTH);
                            Debug.Log(ORIGINAL_HEIGHT);

                            Texture2D texture = new Texture2D(textureMap.width, textureMap.height, TextureFormat.RGBA32, false);
                            texture = ImageTool.ScaleTexture(textureMap, IMAGE_WIDTH, IMAGE_HEIGHT);
                            Color32[] pixels = texture.GetPixels32();
                            Detection model = new Detection();
                            Texture2D result = model.Segmentation(pixels);
                            // result = FlipTexture(result);
                            // StreamWriter writer = new StreamWriter("./test.txt", true);
                            // for (int i = 0; i < result.width; ++i)
                            // {
                            //   for (int j = 0; j < result.height; ++j)
                            //   {
                            //     Color a = result.GetPixel(i, j);
                            //     int r = a.r > 0.5 ? 1 : 0;
                            //     writer.Write(r);
                            //   }
                            //   writer.Write('\n');
                            // }
                            // writer.Close();
                            result = ImageTool.ScaleTexture(result, ORIGINAL_WIDTH, ORIGINAL_HEIGHT);
                            Dictionary<int, int> line = ImageTool.GetLine(result, 'y', 0.5f);
                            // StreamWriter writer1 = new StreamWriter("./indices.txt", true);
                            List<Vector3> WorldPoints = ImageTool.GetWorldPoints(line);
                            // StreamWriter writer = new StreamWriter("./test.txt", true);

                            // for (int i = 0; i < WorldPoints.Count; ++i)
                            // {
                            //   writer.Write("x: ");
                            //   writer.Write(WorldPoints[i].x);
                            //   writer.Write(",");
                            //   writer.Write("y: ");
                            //   writer.Write(WorldPoints[i].y);
                            //   writer.Write("\n");
                            // }
                            // writer.Close();
                            this.a = WorldPoints;
                            mAccessCameraImage = false;
                            isDone = true;
                        }
                        else
                        {
                        counter += 1;
                        }
                    // }
                }
            }
        }
    }
}