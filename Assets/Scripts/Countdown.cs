using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private string _endScene = "End";
    [SerializeField] private float _timeLeft = 60f;
    public Text countdown;
  



    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        int temps = Mathf.RoundToInt(_timeLeft); //arrondi le temps a un entier
        int minutes = temps / 60; // donne le nombre de minutes
        int secs = temps % 60;
        string secondes= "";
       
       
        // Si le temps est plus petit que 0 fin de la parti
        if(_timeLeft < 0){ 
            Debug.Log("Parti perdu");
            _timeLeft = 0f;
            SceneManager.LoadScene(_endScene);
        }
        else if (secs < 10)
        { 
            secondes = "0" + secs.ToString(); 
        }
        else
        { //
            secondes = secs.ToString();
        }
        countdown.text = minutes.ToString("0") + ":" + secondes;
    }

  
}
