using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    [SerializeField] private GameObject _ControlPanel;
    [SerializeField] private PersoMover _persoMover;
    [SerializeField] private GameObject _passwordReminder;
    [SerializeField] private GameObject _btClose;
    
    
    private void Start()
    {
        _persoMover.GetComponent<PersoMover>();

    }

    // Permet de fermer le paneau de contrôle
    public void ClosePanel()
    {
        _ControlPanel.SetActive(false);
        _persoMover.StartMoving();
       
    }

    // Permet de fermer la fenêtre du password reminder et permet au personnage de bouger à nouveau
    public void TakePassword()
    {
        _passwordReminder.SetActive(false);
        _btClose.SetActive(false);
        _persoMover.StartMoving();
        

    }

}
