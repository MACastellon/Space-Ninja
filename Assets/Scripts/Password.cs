using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Password : MonoBehaviour
{
    [SerializeField] private string _Currentpassword;
    int randomNumber;

    //Retourn le mot de passe pour que les autres Componants puisse faire leur vérification
    public string PasswordInfo
    {
        get
        {
            return _Currentpassword;
        }
    }
    private void Start()
    {
        //Génére 4 nmombre aléatoire et constitue le mot de passe
        for (int i = 1; i <= 4; i++)
        {
            randomNumber = Random.Range(0, 10);
            _Currentpassword += randomNumber;
        }

    }
   

}
