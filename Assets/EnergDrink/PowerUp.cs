using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public movement _movement;
    public bool powerup = false;

    //counter
    public float timeRemaining = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //abfrage ob der Spieler das gameobjekt aufsammelt. nach 5 sekunden wird die geschwindigkeit wieder normal
        if (other.gameObject.CompareTag("Player"))
        {
            //erhöhte geschwindigkeit
            _movement.runSpeed = 50;
            gameObject.SetActive(false);
            powerup = true;
        }
    }

   
    
}
