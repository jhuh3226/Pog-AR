using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Case4p2ReStart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Case4");
    }
}
