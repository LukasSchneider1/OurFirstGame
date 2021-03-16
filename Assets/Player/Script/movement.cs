using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


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

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    public Animator animator;
    public AudioSource footstep;
    public AudioSource jumpsound;

    private static int herz;
    private static int zähler;
    Cmovement My_Cmovement = new Cmovement(herz,zähler);


    private void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
        

        for (int i = herz ; herz > 0; i--)
        {
            GameObject.FindGameObjectWithTag("Herz" + i).SetActive(false);
            //GameObject.FindGameObjectWithTag("Herz" + (My_Cmovement.iherz-My_Cmovement.izähler)).SetActive(false);
            break;
        }
        if (herz == 2)
        {
            GameObject.FindGameObjectWithTag("Herz3").SetActive(false);
        }

    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;

            
            
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
       controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
       jump = false;
    

    }

    private void Footstep()
    {
        footstep.Play();
    }
    private void Jump()
    {
        jumpsound.Play();
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
            herz = 4;
           
            if(herz > 0)
            {
                
                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz,zähler);
 
            }
            if (herz == 1)
            {

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);
               

            }




        }

        //Enemy1 wird augeschaltet
        if (other.gameObject.CompareTag("Enemy1"))
        {

            GameObject.FindGameObjectWithTag("Enemy1").SetActive(false);


        }
        //Player bekommt vom ersten Gegner1 schaden
        if (other.gameObject.CompareTag("Enemy_schaden1"))
        {


            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }
            if (herz == 1)
            {

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);


            }

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
[SerializeField()]
public class Cmovement
{
    private int _herz;

    public int iherz
    {
        get { return _herz; }
        set { _herz = value; }
    }

    private int _zähler;

    public int izähler
    {
        get { return _zähler; }
        set { _zähler = value; }
    }


    public Cmovement(int herzk, int zählerk)
    {
        _herz = herzk;
        _zähler = zählerk;
    }

   
}