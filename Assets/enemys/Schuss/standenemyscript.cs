using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standenemyscript : MonoBehaviour
{

    private float speed = 10f;
    public GameObject bullet;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("bullethit"))
        {
           
            Destroy(this.gameObject);
        }

       
    }

}
