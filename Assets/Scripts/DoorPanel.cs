using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _btF;
    [SerializeField] private GameObject _ControlPanel;
    [SerializeField] private PersoMover _persoMover;
    [SerializeField] private CloseUI _btClose;
    
    Collider2D _collider;

    
    

    private bool isTriggered = false;

    private string _PlayerTagName = "Player";
    void Start()
    {
        _persoMover.GetComponent<PersoMover>();
        _btClose.GetComponent<CloseUI>();
   
        _collider = GetComponent<Collider2D>();
        

        _btF.SetActive(false);
        _ControlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Permet d'affichuer le paneau de contrôle quand isTriggered = true et la touche F est enfoncée
        if ( isTriggered && Input.GetKeyDown("f"))
        {
            Debug.Log("Panel");

            _ControlPanel.SetActive(true);
            _btF.SetActive(false);
            _persoMover.StopMoving();
            _persoMover.ResetTarget();
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _btF.SetActive(true);
        isTriggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _btF.SetActive(false);
        isTriggered = false;
    }

}
