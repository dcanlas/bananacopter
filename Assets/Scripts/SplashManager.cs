using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {

    public float autoLoadNextLevel;

    // Use this for initialization
    void Start () {
        if (autoLoadNextLevel > 0)
        {
            Invoke("GoToMenu", autoLoadNextLevel);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
