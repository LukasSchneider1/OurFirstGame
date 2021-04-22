using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player" && Input.GetKey("w"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (other.tag == "Player" && Input.GetKey("s"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else if (other.tag == "Player" && Input.GetKeyDown("a"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
        }

        else if (other.tag == "Player" && Input.GetKey("d"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 0);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        

    }
}
