using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using System;
using Detection;
using System.IO;
namespace ImageTool
{
    public class ImageTool
    {
        // init pixel format
        private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;
        private bool mAccessCameraImage = true;
        private bool mFormatRegistered = false;
        private int ORIGINAL_WIDTH;
        private int ORIGINAL_HEIGHT;
        public const int IMAGE_WIDTH = 256;
        public const int IMAGE_HEIGHT = 320;
        List<Vector3> WorldLine;
        public bool isDone = false;
        private Camera cam;
        // initially run
        public void init()
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
        Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
        {
            Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
            Color[] rpixels = result.GetPixels(0);
            float incX = (1.0f / (float)targetWidth);
            float incY = (1.0f / (float)targetHeight);
            for (int px = 0; px < rpixels.Length; px++)
            {
                rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
            }
            result.SetPixels(rpixels, 0);
            result.Apply();
            return result;
        }
        public Texture2D FlipTexture(Texture2D original)
        {
            Texture2D flipped = new Texture2D(original.height, original.width);
            int xN = original.width;
            int yN = original.height;
            for (int i = 0; i < xN; i++)
            {
                for (int j = 0; j < yN; j++)
                {
                    flipped.SetPixel(j, i, original.GetPixel(i, j));
                }
            }
            flipped.Apply();
            return flipped;
        }
        public Dictionary<int, int> GetLine(Texture2D texture)
        {
            Dictionary<int, List<int>> res = new Dictionary<int, List<int>>();
            for (int i = 0; i < texture.width; ++i)
            {
                for (int j = 0; j < texture.height; ++j)
                {
                    if (texture.GetPixel(i, j).r > 0.5)
                    {
                        if (!res.ContainsKey(i))
                        {
                            res.Add(i, new List<int> { j });
                        }
                        else
                        {
                            var ys = res[i];
                            ys.Add(j);
                            res[i] = ys;
                        }
                    }
                }
            }
            Dictionary<int, int> line = new Dictionary<int, int>();
            foreach (int key in res.Keys)
            {
                var ys = res[key];
                int sum = 0;
                for (int i = 0; i < ys.Count; ++i)
                {
                    sum += ys[i];
                }
                line.Add(key, sum / ys.Count);
            }
            return line;
        }
        public List<Vector3> GetWorldPoints(Dictionary<int, int> line)
        {
            List<Vector3> res = new List<Vector3>();
            foreach (int x in line.Keys)
            {
                int y = line[x];
                res.Add(cam.ScreenToWorldPoint(new Vector3(x, y, cam.farClipPlane)));
                //  cam.nearClipPlane
                // cam.farClipPlane
                // cam.nearClipPlane * 0.95f + cam.farClipPlane * 0.05f
            }
            return res;
        }
        public List<Vector3> GetWorldLine()
        {
            return this.WorldLine;
        }
        public void OnTrackablesUpdated()
        // public void GetWorldLine()
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
                        Texture2D texture = new Texture2D(image.Width, image.Height, TextureFormat.RGBA32, false);
                        image.CopyToTexture(texture);
                        texture = ScaleTexture(texture, IMAGE_WIDTH, IMAGE_HEIGHT);
                        Color32[] pixels = texture.GetPixels32();
                        Detection.Detection model = new Detection.Detection();
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
                        result = ScaleTexture(result, ORIGINAL_WIDTH, ORIGINAL_HEIGHT);
                        Dictionary<int, int> line = GetLine(result);
                        // StreamWriter writer1 = new StreamWriter("./indices.txt", true);
                        List<Vector3> WorldPoints = GetWorldPoints(line);
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
                        this.WorldLine = WorldPoints;
                        mAccessCameraImage = false;
                        isDone = true;
                    }
                }
            }
        }
    }
}