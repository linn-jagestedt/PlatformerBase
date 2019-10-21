using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour
{
    public string Scene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player") 
        { SceneManager.LoadScene(Scene, LoadSceneMode.Single); }
    }
}
