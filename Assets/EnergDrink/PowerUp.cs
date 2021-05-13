using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public movement _movement;
    public bool powerup = false;

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
        if (other.gameObject.CompareTag("Player"))
        {
            _movement.runSpeed = 50;
            gameObject.SetActive(false);
            powerup = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //for (float i = 0; i < timeRemaining; i += Time.deltaTime) { 

    //    //    if (i == timeRemaining)
    //    //    {
    //    //        _movement.runSpeed = 1;
                
    //    //    }
    //    //    Debug.Log("RAN OUT!");
    //    //}

    //    //Debug.Log("TIME RAN OUT!");

        
    //}
    
}
