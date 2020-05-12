using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    [SerializeField] private InputField _passwordPrompt;

    // Start is called before the first frame update

   /*Permet d'écrire un chiffre dans le champ text du paneau de contrôle*/
    public void TypeNumberOne()
    {

        _passwordPrompt.text += 1;
    }
    public void TypeNumberTwo()
    {

        _passwordPrompt.text += 2;
    }
    public void TypeNumberThree()
    {

        _passwordPrompt.text += 3;
    }
    public void TypeNumberFour()
    {

        _passwordPrompt.text += 4;
    }
    public void TypeNumberFive()
    {

        _passwordPrompt.text += 5;
    }
    public void TypeNumberSix()
    {

        _passwordPrompt.text += 6;
    }
    public void TypeNumberSeven()
    {

        _passwordPrompt.text += 7;
    }
    public void TypeNumberEight()
    {

        _passwordPrompt.text += 8;
    }
    public void TypeNumberNine()
    {

        _passwordPrompt.text += 9;
    }
    public void TypeNumberZero()
    {

        _passwordPrompt.text += 0;
    }
    // Permet de Reset le password
    public void ResetPassword()
    {
        Debug.Log("InputField reset");
        _passwordPrompt.text =null;
    }
   

}
