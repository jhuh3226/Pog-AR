using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour {

public void RestartGame()
    {
        SceneManager.LoadScene("Case1-2");
    }

public void RestartGame2()
    {
        SceneManager.LoadScene("Case1");
    }

}
