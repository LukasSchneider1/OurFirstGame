using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SchadenPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Platform selber x-Wert
       

        if (other.gameObject.CompareTag("Enemy_schaden"))
        {

            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            print("hsldfh");

        }
       



    }
}
