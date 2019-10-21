using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string Scene;

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
    }
}
