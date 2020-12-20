using System;
using Unity.Barracuda;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Detection
{
  public class Detection
  {
    // image size
    public const int IMAGE_WIDTH = 256;
    public const int IMAGE_HEIGHT = 320;
    public const int offset = 4; // since the pixel is rgba
    // image channel-wise means/stds
    private static readonly float[] IMAGE_MEANS = new float[] { 0.485f, 0.456f, 0.406f };
    private static readonly float[] IMAGE_STDS = new float[] { 0.229f, 0.224f, 0.225f };
    // name of input/output
    private const string INPUT_NAME = "input";
    private const string OUTPUT_NAME = "output";

    private IWorker worker;
    private string[] labels;

    // initial run
    public Detection()
    {
      // load onnx model from path
      Model model = ModelLoader.Load((NNModel)Resources.Load("model"));
      this.worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, model);
    }

    public Texture2D Segmentation(Color32[] pixels)
    {
      using (var input = TransformInput(pixels, IMAGE_WIDTH, IMAGE_HEIGHT))
      {
        var output = this.worker.Execute(input).PeekOutput();
        Color32[] res = new Color32[160 * 128];

        for (int i = 0; i < res.Length; ++i) {
          var v = Sigmoid(output[0, i/128, i%128, 0]);
          byte rgb = (byte)(v * 255.0f);
          // naive grayscale
          res[i].r = rgb;
          res[i].g = rgb;
          res[i].b = rgb;
          res[i].a = 255;
        }

        Texture2D tex = new Texture2D(128, 160, TextureFormat.RGBA32, false);
        tex.SetPixels32(res);
        tex.Apply(false);
        tex = FlipTexture1(tex);

        byte[] _bytes = tex.EncodeToPNG();
        System.IO.File.WriteAllBytes("./test.png", _bytes);

        return tex;
      }
    }

    public Texture2D FlipTexture1(Texture2D original)
    {
      Texture2D flipped = new Texture2D(original.width, original.height);

      int xN = original.width;
      int yN = original.height;

      for (int i = 0; i < xN; i++)
      {
        for (int j = 0; j < yN; j++)
        {
          flipped.SetPixel(i, yN - j - 1, original.GetPixel(i, j));
        }
      }

      flipped.Apply();

      return flipped;
    }

    public Tensor TransformInput(Color32[] pixels, int width, int height)
    {
      float[] floatValues = new float[width * height * (offset-1)];

      for (int i = 0; i < pixels.Length; ++i)
      {
        var pixel = pixels[i];
        var idx = i*(offset-1);
        // for each channel (R/G/B) (except channel 'A')
        floatValues[idx + 0] = ((pixel.r / 255.0f * (pixel.a / 255.0f)) - IMAGE_MEANS[0]) / IMAGE_STDS[0];  // R
        floatValues[idx + 1] = ((pixel.g / 255.0f * (pixel.a / 255.0f)) - IMAGE_MEANS[1]) / IMAGE_STDS[1];  // G
        floatValues[idx + 2] = ((pixel.b / 255.0f * (pixel.a / 255.0f)) - IMAGE_MEANS[2]) / IMAGE_STDS[2];  // B
      }

      return new Tensor(1, height, width, offset-1, floatValues);
    }

    public float Sigmoid(float value)
    {
      float k = (float)Math.Exp(value);
      return k / (1.0f + k);
    }
  }
}
