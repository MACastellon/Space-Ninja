using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManagement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameManager _gm;
    void Start()
    {
        _gm.GetComponent<GameManager>();
    }

    // Update is called once per frame
   public void WinOrLose(bool result)
    {
        if (result)
        {
            _gm.Typewin();
        }
        else {
            _gm.Typelose();
           }
    }
}
