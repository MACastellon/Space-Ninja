using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMover : MonoBehaviour
{
    private string _isMovingAnim = "isMoving";
    private string _isTeleportedAnim = "isTeleported";

    [SerializeField] private float _persoVitesse = 1;
    [SerializeField] private float _persoVitesseReset = 1;
    [SerializeField] private GameObject _persoDir;
    [SerializeField] private AudioClip _walkSound;
    [SerializeField] private AudioClip _teleportedSound;
    
    
    private bool persoMoving;

    private Vector2 target;

    AudioSource _audio;
    Animator _animator;
    Rigidbody2D _body = null;
    

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        target = new Vector2(transform.position.x, transform.position.y);

        
    }
    private void OnMouseDown()
    {
        Debug.Log("mouse down");
    }


    void Update()
    {
      
  
        //Position du curseur  et place le GameObject Target la position du curseur
        if (Input.GetMouseButtonDown(0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        // Si le perso bouge fait jouer son animaton isMoving
        if (persoMoving) {
            _animator.SetBool(_isMovingAnim, true);
            //_audio.clip = _walkSound;
            //_audio.Play();
        }else if(persoMoving==false){
            _animator.SetBool(_isMovingAnim, false);
           
            
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
          

        }//_persoDir.transform.position;
        //Position du curseur 
        Vector2 curseurPos = target;
        Debug.Log(_persoDir.transform.position);
        Vector2 maPos = transform.position;//Positon du perso
        Vector2 deltaPos = curseurPos - maPos;

        //Récupère l'angle en radians et le converti en degrés
        float angleRad = Mathf.Atan2(deltaPos.y,deltaPos.x) * Mathf.Rad2Deg;
        _body.rotation = angleRad;

        //Calcul de la distance pour régler le bug 
        float distance = Vector2.Distance(curseurPos, maPos);
        if (distance > 0.1f) 
        {
            // Retourne une vecteur 2 d'ne somme totale de 1 en lien avec la directon
            Vector2 direction = new Vector2(deltaPos.x, deltaPos.y).normalized;

            //En pyhsique, on se dépace avec a vélocité plutot que par le transform
            _body.velocity = direction * _persoVitesse;
            persoMoving = true;
        
        }else {
            //_body.velocity = new Vector2(0,0);
            _body.velocity = Vector2.zero;
            persoMoving = false;
        } 
    }
    // Replace la Target sur le personnage
    public void ResetTarget()
    {
        Debug.Log("potiosion reset");
        target = new Vector2(transform.position.x, transform.position.y);
    }
    // Fait arrêter les mouvements du personnage
    public void StopMoving() {
        _persoVitesse = 0;
        _animator.SetBool(_isMovingAnim, false);
   

    }
    // Permet au personnage de bouger
    public void StartMoving() {
        _persoVitesse = _persoVitesseReset;
    }
    // Permet de faire jouer les animations et sons de téléportation du personnage
    public void PersoTeleported()
    {
        _audio.clip = _teleportedSound;
        _audio.Play();
        _animator.SetTrigger(_isTeleportedAnim);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {    
        
       
    }
   
    void OnCollisionExit2D(Collision2D other)
    {
       
    }
}
