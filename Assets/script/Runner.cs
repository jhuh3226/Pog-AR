// using UnityEngine;
// using UnityEngine.UI;
// using ImageTool;
// using Detection;
// using Vuforia;

// class Runner : MonoBehaviour
// {
//     private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;
//     private bool mAccessCameraImage = true;
//     private bool mFormatRegistered = false;

//     private Camera cam;

//     public float speed;
//     Vector3 startPosition;
//     Vector3 endPosition;
//     int counter = 0;
//     public GameObject ball;
//     ImageTool.ImageTool i;
// 		private bool isDone = false;

//     void Start()
//     {
//         // set candidate pixel format
//         mPixelFormat = PIXEL_FORMAT.RGBA8888;
//         // Register Vuforia life-cycle callbacks:
//         VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
//         VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
//         cam = Camera.main;
//     }

// 		void OnVuforiaStarted()
//     {
//       // set image format
//       if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
//       {
//         Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
//         mFormatRegistered = true;
//       }
//       else
//       {
//         Debug.LogError(
//             "\nFailed to register pixel format: " + mPixelFormat.ToString() +
//             "\nThe format may be unsupported by your device." +
//             "\nConsider using a different pixel format.\n");
//         mFormatRegistered = false;
//       }
//     }

//     void Update()
//     {
//         if (isDone)
//         {
//             var a = ImageTool.GetWorldLine();
//             if (counter < a.Count)
//             {
//                 float newX = a[counter].x - a[0].x + a[0].x + 3.0f;
//                 float newY = a[counter].y - a[0].y + a[0].y + 2.0f;
//                 ball.transform.position = new Vector3(newX, newY, a[counter].z);
//                 counter += 5;
//             }
//             else
//             {
//                 counter = 0;
//             }
//         }
//     }

//     public void OnTrackablesUpdated()
//     {
//       if (mFormatRegistered)
//       {
//         if (mAccessCameraImage)
//         {
//           Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);
//           ORIGINAL_WIDTH = image.Width;
//           ORIGINAL_HEIGHT = image.Height;
//           if (image != null)
//           {
//             if (counter == 100)
//             {
//               //Texture2D texture = new Texture2D(image.Width, image.Height, TextureFormat.RGBA32, false);
//               //image.CopyToTexture(texture);
// 		          Debug.Log("textureMap.height" + textureMap.height);

// 							Texture2D texture = new Texture2D(textureMap.width, textureMap.height, TextureFormat.RGBA32, false);
//               texture = ScaleTexture(textureMap, IMAGE_WIDTH, IMAGE_HEIGHT);
//               Color32[] pixels = texture.GetPixels32();
//               Detection.Detection model = new Detection.Detection();
//               Texture2D result = model.Segmentation(pixels);
//               // result = FlipTexture(result);
//               // StreamWriter writer = new StreamWriter("./test.txt", true);
//               // for (int i = 0; i < result.width; ++i)
//               // {
//               //   for (int j = 0; j < result.height; ++j)
//               //   {
//               //     Color a = result.GetPixel(i, j);
//               //     int r = a.r > 0.5 ? 1 : 0;
//               //     writer.Write(r);
//               //   }
//               //   writer.Write('\n');
//               // }
//               // writer.Close();
//               result = ScaleTexture(result, ORIGINAL_WIDTH, ORIGINAL_HEIGHT);
//               Dictionary<int, int> line = ImageTool.GetLine(result);
//               // StreamWriter writer1 = new StreamWriter("./indices.txt", true);
//               List<Vector3> WorldPoints = ImageTool.GetWorldPoints(line);
//               // StreamWriter writer = new StreamWriter("./test.txt", true);

//               // for (int i = 0; i < WorldPoints.Count; ++i)
//               // {
//               //   writer.Write("x: ");
//               //   writer.Write(WorldPoints[i].x);
//               //   writer.Write(",");
//               //   writer.Write("y: ");
//               //   writer.Write(WorldPoints[i].y);
//               //   writer.Write("\n");
//               // }
//               // writer.Close();
//               this.WorldLine = WorldPoints;
//               mAccessCameraImage = false;
//               isDone = true;
//             }
//             else
//             {
//               counter += 1;
//             }
//           }
//         }
//       }
//     }
// }