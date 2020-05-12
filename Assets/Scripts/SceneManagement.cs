using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private string _GameScene = "Game";

    private void Start()
    {
        //_gm.GetComponent<GameManager>();
    }

    //Permet de se rendre la scene Game
    public void PlayGame()
    {
        SceneManager.LoadScene(_GameScene);
    }

    //Permet de fermer l'application
    public void QuitGameBtn()
    {
        Application.Quit();
    }
   /* public void Replay()
    {
        _gm.Replay();
    }*/
}
