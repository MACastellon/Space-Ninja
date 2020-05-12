using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailEntre : MonoBehaviour
{
    private string _PlayerTagName = "Player";

    [SerializeField] private PersoMover _persoMover;
    [SerializeField] private GameObject _Player;
    [SerializeField] private GameObject _PortalSpawnPoint;
    


    
 

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        /* Si le personnage entre en collision avec un portail déclanche son animation et  teleporte le */
        if (other.tag == _PlayerTagName)
        {
            _persoMover.PersoTeleported();
            StartCoroutine(Teleport());
           
        
        } 
    }
    /*Le IEnumerator Teleport() permet d'éxecuter le cote apres 0.5 secondes d'attente ce qui laisse du tmeps à 
     * l'animation et lees sot de jouer*/
    IEnumerator Teleport() {
        yield return new WaitForSeconds(0.5f);
        _Player.transform.position = new Vector2(_PortalSpawnPoint.transform.position.x, _PortalSpawnPoint.transform.position.y);
        PortalTaken();
       
    }
    /*Replace le Target sur le personnage pour pas qu'il aille se promener ailleur*/
    public void PortalTaken()
    {
        _persoMover.ResetTarget();
    }


}
