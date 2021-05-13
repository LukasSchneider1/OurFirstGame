using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//github
[RequireComponent(typeof(AudioSource))]
public class movement : MonoBehaviour
{

    // Start is called before the first frame update

    //Geschwindigkeit

    // Start is called before the first frame update

    //Sprung
    public bool run = false;
    public endgegnerscript _endgegner;
    private Rigidbody2D _rigidbody;
    public CharacterController2D controller;

    public float runSpeed = 30;
    float horizontalMove = 0f;
    bool jump = false;

    public Animator animator;
    public AudioSource backgroundmusik;
    public AudioSource footstep;

    public PowerUp _powerUP;
    public invisible invisible;

    private static int herz = 4;
    private static int zähler;
    Cmovement My_Cmovement = new Cmovement(herz, zähler);

    private int diamantValue = 0;
   
    

    public GameObject canvasObject;
    public GameObject canvasObject1;    
  

    private void Start()
    {       
        makeDisable1();
        _rigidbody = GetComponent<Rigidbody2D>();
        //GameObject.FindGameObjectWithTag("moreDiamants").SetActive(false);

        for (int i = herz; herz > 0; i--)
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

        backgroundmusik.volume = PlayerPrefs.GetFloat("volume");
        
        //Ende();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }

        if (Input.anyKey || herz < 4)
        {
            makeDisable();            
        }

        if (_powerUP.powerup)
        {
            if(_powerUP.timeRemaining > 0)
            {
                _powerUP.timeRemaining -= Time.deltaTime;
            }
            else
            {
                runSpeed = 30;
                _powerUP.powerup = false;
            }
        }

        if (invisible.visible)
        {
            if (invisible.timeRemaining > 0)
            {
                invisible.timeRemaining -= Time.deltaTime;
            }
            else
            {                
                invisible.visible = false;
                invisible.renderer.enabled = true;
                
            }
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
    
    public void makeDisable1()
    {
        canvasObject1.SetActive(false);
    }

    public void makeDisable()
    {
        canvasObject.SetActive(false);

    }

    public void makeEnable1()
    {
        canvasObject1.SetActive(true);
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
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
            Destroy(GameObject.FindGameObjectWithTag("BulletLeft"));
        }
        //Player bekommt vom ersten Gegner schaden
        if (other.gameObject.CompareTag("Enemy_schaden"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }



        }

       

        //Enemy1 wird augeschaltet
        if (other.gameObject.CompareTag("Enemy1"))
        {

            GameObject.FindGameObjectWithTag("Enemy1").SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
            Destroy(GameObject.FindGameObjectWithTag("BulletLeft"));


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

        }
        if (other.gameObject.CompareTag("Falldown"))
        {
            herz = 4;
            if (herz > 0)
            {
                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);
            }

        }

        //Prüfen ob die Bullets den Player treffen
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BulletLeft"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }



        }

        if (other.gameObject.CompareTag("wand1") || other.gameObject.CompareTag("wand2"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }



        }
        //Spiken1-2
        if (other.gameObject.CompareTag("Spike1") || other.gameObject.CompareTag("Spike2") || other.gameObject.CompareTag("Spike3") || other.gameObject.CompareTag("Spike4") || other.gameObject.CompareTag("Spike5"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }



        }


        if (other.gameObject.CompareTag("Block"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }
        }


       

        //Abfrage ob er noch ein leben hat
        if (herz == 1)
        {
            SceneManager.LoadScene("Menü");

            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);


        }

        if (other.gameObject.CompareTag("door"))
        {

            GameObject.FindGameObjectWithTag("moreDiamants").SetActive(true);
            print("zuwenig");

        }

       



    }
   
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;

        }

       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (diamantValue == 3 && other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("SecondLevel");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }

       else if (other.gameObject.CompareTag("Finish") && diamantValue <= 2)
        {
            makeEnable1();

            if (Input.GetKeyDown("w"))
            {

                transform.position = new Vector3(-10, 2, 0);
                makeDisable1();
            }
        }

        

        if (diamantValue > 2 && other.gameObject.CompareTag("FinishSecondLevel"))
        {

            SceneManager.LoadScene("menü");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }

      else if (other.gameObject.CompareTag("FinishSecondLevel") && diamantValue <= 2)
        {
            makeEnable1();

            if (Input.GetKeyDown("w"))
            {

                transform.position = new Vector3(0, -1, 0);
                makeDisable1();
            }
        }

       

        if (other.gameObject.CompareTag("signrun"))
        {
            _rigidbody.gravityScale = 1;
            _endgegner.Update();
            _endgegner.gegnerstart = true;
           
        }
        if (other.gameObject.CompareTag("Bullet"))
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
                SceneManager.LoadScene("Menü");

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);


            }


        }


        //Diamant
        if (other.gameObject.CompareTag("Diamant"))
        {
            
            GameObject.FindGameObjectWithTag("Diamant").SetActive(false);
            ScoreManager.instance.ChangeScore(diamantValue);
            diamantValue++;
        }
        if (other.gameObject.CompareTag("Diamant2"))
        {
           
            GameObject.FindGameObjectWithTag("Diamant2").SetActive(false);
            ScoreManager.instance.ChangeScore(diamantValue);
            diamantValue++;
        }
        if (other.gameObject.CompareTag("Diamant3"))
        {
           
            GameObject.FindGameObjectWithTag("Diamant3").SetActive(false);
            ScoreManager.instance.ChangeScore(diamantValue);
            diamantValue++;
        }
        if (other.gameObject.CompareTag("Diamant4"))
        {
          
            GameObject.FindGameObjectWithTag("Diamant4").SetActive(false);
            ScoreManager.instance.ChangeScore(diamantValue);
            diamantValue++;
        }

        if (other.gameObject.CompareTag("Endgegner"))
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
                SceneManager.LoadScene("Menü");

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);


            }

        }

        if (other.gameObject.CompareTag("gravitationänderung"))
        {
            _rigidbody.gravityScale = 3;
        }


        if (diamantValue == 3 && other.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene("menü");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }

        else if (other.gameObject.CompareTag("door") && diamantValue <= 2)
        {
            makeEnable1();

            if (Input.GetKeyDown("w"))
            {

                transform.position = new Vector3(-3, -1, 0);
                makeDisable1();
            }
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