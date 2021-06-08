using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
{
    // Start is called before the first frame update

    public bool visible = false;
    //counter
    public float timeRemaining = 5;
    public Renderer renderer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //abfrage ob der Spieler das gameobjekt aufsammelt. nach 5 sekunden wird der spieler wieder sichtbar
        if (other.gameObject.CompareTag("Player"))
        {
            renderer.enabled = false;
            gameObject.SetActive(false);
            visible = true;
        }
    }

}
