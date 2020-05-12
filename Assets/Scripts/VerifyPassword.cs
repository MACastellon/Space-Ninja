using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class VerifyPassword : MonoBehaviour
{
    private string _goodPasswordAnim = "goodPassword";
    private string _badPasswordAnim = "badPassword";

    [SerializeField] private Password _password;
    [SerializeField] private PersoMover _persoMover;
    [SerializeField] private Door _door;
    [SerializeField] private Animator _lightAnimator;

    [SerializeField] private string _Currentpassword;
    [SerializeField] private InputField _promtPassword;
    [SerializeField] private GameObject _Inputfield;
    bool passwordGood = false;

     public bool goodPassword {
        get { return passwordGood; }
    }
    

    private void Start()
    {
        _persoMover.GetComponent<PersoMover>();
        _password.GetComponent<Password>();
        _door.GetComponent<Door>();
        _lightAnimator.GetComponent<Animator>();
       
    
    }
    public void CheckPassword()
    {
        // Si le password est bon déclanche l'animation de lumière et appele la méthode GoodPass()
        if (_promtPassword.text == _password.PasswordInfo)
        {   
            Debug.Log("Bon Password");
            _lightAnimator.SetTrigger(_goodPasswordAnim);
            StartCoroutine(GoodPass());
            
        }
        //Sinon déclanche l'animation de lumière badPassword;
        else
        {
            Debug.Log("Mauvais MP");
            _promtPassword.text = null;
            _lightAnimator.SetTrigger(_badPasswordAnim);
            
        }


    }

    //Après 1 seconde enleve le paneau de contrôle, permet au joueur de bouger ,reset la Target et ouvre la porte
    IEnumerator GoodPass()
    {
        yield return new WaitForSeconds(1f);
        _Inputfield.SetActive(false);
        _persoMover.StartMoving();
        _persoMover.ResetTarget();

        _door.OpenDoor();
        passwordGood = true;
   


    }
}
