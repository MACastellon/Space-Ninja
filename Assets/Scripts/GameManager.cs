using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool gameWon;

    [SerializeField] AudioClip _gameBaseMusic;
    [SerializeField] AudioClip _gameWonMusic;
    [SerializeField] AudioClip _gameLoseMusic;


    

    AudioSource _audio;

    public bool verifyGame {
        get { return gameWon; }
    }
   
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _gameBaseMusic;
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameWon);
    }
    public void Win() {
        gameWon = true;
        _audio.clip = _gameWonMusic;
        _audio.Play();
       
        
    }

    public void Lose() {
        gameWon = false;
        _audio.clip = _gameLoseMusic;
        _audio.Play();
        
    }
    // Detruit le gameobject : ne fonctionne pas... :(
    public void Replay()
    {
      
       
    }
    public void Typewin() {

    }
    public void Typelose()
    {
        
    }


}
