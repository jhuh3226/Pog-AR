using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


namespace DLTool
{
  public class ImageTool  
  {
    public static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
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

    public static Dictionary<int, int> GetLine(Texture2D texture, char axis, float ratio)
    {
      Dictionary<int, (int min, int max)> res = new Dictionary<int, (int min, int max)>();

      if (axis == 'y') {
        for (int j = 0; j < texture.height; ++j)
        {
          for (int i = 0; i < texture.width; ++i)
          {
            if (texture.GetPixel(i, j).r > 0.5)
            {
              if (!res.ContainsKey(j))
              {
                res.Add(j, (i, i));
              }
              else
              {
                int min = res[j].Item1 > i ? i : res[j].Item1;
                int max = res[j].Item2 < i ? i : res[j].Item2;
                var newT = (min, max);
                res[j] = newT;
              }
            }
          }
        }
      } else {  // axis == 'x'
        for (int i = 0; i < texture.width; ++i)
        {
          for (int j = 0; j < texture.height; ++j)
          {
            if (texture.GetPixel(i, j).r > 0.5)
            {
              if (!res.ContainsKey(i))
              {
                res.Add(i, (j, j));
              }
              else
              {
                int min = res[i].Item1 > j ? j : res[i].Item1;
                int max = res[i].Item2 < j ? j : res[i].Item2;
                var newT = (min, max);
                res[i] = newT;
              }
            }
          }
        }
      }

      Dictionary<int, int> line = new Dictionary<int, int>();

      StreamWriter writer = new StreamWriter("./line.txt", true);
      foreach (int key in res.Keys)
      {
        writer.Write("y: ");
        writer.Write(key);
        writer.Write(", ");
        writer.Write("x: (");
        writer.Write(res[key].Item1);
        writer.Write(", ");
        writer.Write(res[key].Item2);
        writer.Write(")\n");        

        var point = (float)res[key].Item1 * (1.0f - ratio) + (float)res[key].Item2 * ratio;

        line.Add(key, (int)point);
      }
      writer.Close();

      writer = new StreamWriter("./test.txt", true);
      foreach (int key in line.Keys) {
        writer.Write("x: ");
        writer.Write(key);
        writer.Write(", ");
        writer.Write("y: ");
        writer.Write(line[key]);
        writer.Write("\n");
      }
      writer.Close();

      return line;
    }

    public static List<Vector3> GetWorldPoints(Dictionary<int, int> line)
    {
      List<Vector3> res = new List<Vector3>();

      foreach (int x in line.Keys)
      {
        int y = line[x];

        res.Add(DlCase2Runner.cam.ScreenToWorldPoint(new Vector3(x, y, 1.0f)));
      }

      return res;
    }
  }
}