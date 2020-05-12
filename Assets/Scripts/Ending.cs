using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class Ending : MonoBehaviour
{
    private string _PlayerTagName = "Player";
    private string _WinScene = "Win";

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si le joueur entre en collisin va à la scene Win
        if (other.gameObject.tag == _PlayerTagName)
        {
            Debug.Log("toucher");
            SceneManager.LoadScene(_WinScene);
        }
    }
}
