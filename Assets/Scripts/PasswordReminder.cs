using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PasswordReminder : MonoBehaviour
{
    [SerializeField] private GameObject _btF;
    [SerializeField] private GameObject _btTake;
    [SerializeField] private GameObject _passwordReminder;
    [SerializeField] private GameObject _passwordInventory;

    [SerializeField] private Password _password;
    [SerializeField] private PersoMover _persoMover;

    [SerializeField] private Text _passwordInfo;
   
    private bool isTriggered = false;
    private bool passwordTaken = false;
    public bool PasswordInventory
    {
        get
        {
            return passwordTaken;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _passwordReminder.SetActive(false);
        _password.GetComponent<Password>();
        _persoMover.GetComponent<PersoMover>();
        
  
    }
    private void Update()
    {
        /*Si isTriggered = true et la touche f est enfoncé  afficher le password reminder enleve le bouton F
         et reset la target et arrête le  mouvement du personnage*/
        if (isTriggered && Input.GetKeyDown("f"))
        {
            Debug.Log("Password reminder");
            _passwordInfo.text += _password.PasswordInfo;
            _passwordReminder.SetActive(true);
            _btF.SetActive(false);
            _btTake.SetActive(true);
            _persoMover.ResetTarget();
            _persoMover.StopMoving();
            
        }
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        isTriggered = true;
        _btF.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        _passwordReminder.SetActive(false);
        _btF.SetActive(false);
    }

   


}
