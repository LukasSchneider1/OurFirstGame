using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(AudioSource))]
public class movement : MonoBehaviour
{

    // Start is called before the first frame update

    //Geschwindigkeit

    // Start is called before the first frame update

    //Sprung
    private float JumpForce = 15;
    private Rigidbody2D _rigidbody;
    public CharacterController2D controller;


    public Animator animator;
    public AudioSource footstep;
    public AudioSource jumpsound;

    private int herz = 3;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {

            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

            animator.SetBool("IsJumping", true);
            jumpsound.Play();


        }
        else if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            animator.SetBool("IsJumping", false);
        }

        


    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        var speed = 30;
        var movement = Input.GetAxisRaw("Horizontal") * speed;

        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        controller.Move(movement * Time.fixedDeltaTime, false, false);
        // _rigidbody.AddTorque(rotation * rotationSpeed * Time.fixedDeltaTime);

    }

    private void Footstep()
    {

        footstep.Play();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Platform selber x-Wert
        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = other.transform;
            
        }

        //Enemy wird augeschaltet
        if (other.gameObject.CompareTag("Enemy"))
        {

            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
            

        }
        //Player bekommt vom ersten Gegner schaden
        if (other.gameObject.CompareTag("Enemy_schaden"))
        {

            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            herz = herz - 1;

        }

        //Enemy1 wird augeschaltet
        if (other.gameObject.CompareTag("Enemy1"))
        {

            GameObject.FindGameObjectWithTag("Enemy1").SetActive(false);


        }
        //Player bekommt vom ersten Gegner1 schaden
        if (other.gameObject.CompareTag("Enemy_schaden1"))
        {

            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            herz = herz - 1;

        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;

        }
    }

   



   



}
