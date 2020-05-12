using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class PersoInventaire : MonoBehaviour
{
    private string _KeyTagName = "Key"; //Le tag de la clé
    private string _normalDoorTageName = "normalDoor";
    private string _keyF = "f";
    bool isTriggered;
    private bool gotKey = false; // bool qui sert à savoir si on à la clé ou non
    int keyParts = 0;
    [SerializeField] private GameObject _btF;
    [SerializeField] private GameObject _passwordReminder;
    [SerializeField] GameObject _keyReminder;
    [SerializeField] private Password _password;
    [SerializeField] private PersoMover _persoMover;
    [SerializeField] private Door _door;
    [SerializeField] private Text _passwordInfo;
    [SerializeField] private Button _takePassword;

    [SerializeField] UnityEvent ShowPassword;

    public bool haveKey {
        get { return gotKey; }
    }
    // Start is called before the first frame update
    void Start()
    {

        ShowPassword.AddListener(TakePassword);
        _password.GetComponent<Password>();
        _persoMover.GetComponent<PersoMover>();
        _door.GetComponent<Door>();
        _takePassword.GetComponent<Button>();
        _passwordReminder.SetActive(false);
        _keyReminder.SetActive(false);
        _passwordInfo.text += _password.PasswordInfo;
    }

    // Update is called once per frame
    void Update()
    {
       
        _takePassword.onClick.AddListener(TakePassword);

        // Si triggered = true et la touche F est enfoncée ouvre la porte et enleve le reminder de la clé
        if (isTriggered && Input.GetKeyDown(_keyF)) {
            _door.OpenDoor();
            _keyReminder.SetActive(false);
        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
          Si l'objet en collision a le tag Key detruit l'objet 
         incrémente keyParts et vérifie is j'ai les trois parti avec
         la méthode GotKey()
         */
        if (other.gameObject.tag == _KeyTagName) {
            Destroy(other.gameObject);
            keyParts++;
            GetKey();
            Debug.Log("Clé Ramasser");
        }
        /*
         Si la collision est avec une porte normal et la clé est assemblée affiche 
         le bouton F et met isTriggered = true
         */
        if (other.gameObject.tag == _normalDoorTageName && gotKey) {
            _btF.SetActive(true);
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _btF.SetActive(false);
        isTriggered = false;
    }
    private void TakePassword() {
        _passwordReminder.SetActive(true);
    }

    //Vérifie si les 3 partis de la clé on été ramasser si oui affiche le reminder le la clé dansl'inventaire
    private void GetKey ()
    {
        if (keyParts == 3)
        {
            gotKey = true;
            _keyReminder.SetActive(true);
        }
    }
}
