using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackQR : MonoBehaviour
{
    public void RestartQR()
    {
        SceneManager.LoadScene("Case1QR");
    }
}
