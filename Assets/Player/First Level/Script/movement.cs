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
    public endgegnerscript _endgegner;
    //Sprung
    public bool run = false;
    //Verlinkung zum Rigidbody
    private Rigidbody2D _rigidbody;
    //CharacterController verlinkung
    public CharacterController2D controller;

    //beweg geschwindigkeit
    public float runSpeed = 30;
    //horizontale bewegung
    float horizontalMove = 0f;
    //Jump true oder false
    bool jump = false;

    //Animator verlinkung
    public Animator animator;
    //Audiosource hintergrundmusik
    public AudioSource backgroundmusik;
    //footstep sound
    public AudioSource footstep;

    //PowerUp: schnellere geschwindigkeit
    public PowerUp _powerUP;
    //unsichbar 
    public invisible invisible;
    
    //gesamt Leben
    private static int herz = 4;

    //Die variable mit der das Herz abgezogen wird. Bei zwei Tode ist die Variable auf 2. Das Herz wird minus 2 subtrahiert 
    private static int zähler;

    //Konstruktur
    Cmovement My_Cmovement = new Cmovement(herz, zähler);

    //Variable für die Diamanten
    private int diamantValue = 0;
   
    

    public GameObject canvasObject;
    public GameObject canvasObject1;    
  

    private void Start()
    {       
        makeDisable1();
        _rigidbody = GetComponent<Rigidbody2D>();
        //setzt ein Herz auf false sobald der Spieler ein Leben verliert
        for (int i = herz; herz > 0; i--)
        {
            GameObject.FindGameObjectWithTag("Herz" + i).SetActive(false);
            break;
        }

        //Wenn der Spieler 2 Herzen hat wird das 3 Herz deaktiviert
        if (herz == 2)
        {
            GameObject.FindGameObjectWithTag("Herz3").SetActive(false);
        }
        
    }

    private void Update()
    {        

        //holt sich die musiklautstärke aus dem String "volume"
        backgroundmusik.volume = PlayerPrefs.GetFloat("volume");
        
        //Spieler bewegt sich horizontal
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Animation wenn der Spieler sich bewegt
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        //abfrage ob er die leertaste drückt
        if (Input.GetButtonDown("Jump"))
        {
            //setzt die animation auf true
            animator.SetBool("IsJumping", true);
            jump = true;
        }

        //Der anfangstext wird ausgeblendet wenn der Spieler eine taste drückt
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

    //Wenn die Figur den Boden berührt wird diese Funktion ausgeführt
    public void OnLanding()
    {
        //setzt die Jumpanimation auf false
        animator.SetBool("IsJumping", false);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //Der Spieler bewegt sich
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;


    }

    private void Footstep()
    {
        footstep.Play();
    }
    
    //setzt den ersten Text auf false
    public void makeDisable1()
    {
        canvasObject1.SetActive(false);
    }
    //setzt den Text auf false
    public void makeDisable()
    {
        canvasObject.SetActive(false);

    }
    //setzt den Text auf false
    public void makeEnable1()
    {
        canvasObject1.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
        //abfrage ob der Spieler das Gameobjekt mit dem Tag "Platform" berührt
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
        //Spieler bekommt Herzen abgezogen
        if (other.gameObject.CompareTag("Enemy_schaden"))
        {
            herz = 4;

            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                //Scene wird neu geladen
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //die Variablen werden in den Konstruktor hinzugefügt
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
        //Spieler bekommt Herzen abgezogen
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
        //Spieler fällt von der Map runter
        //Spieler bekommt Herzen abgezogen
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
        //Spieler bekommt Herzen abgezogen
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
        //Spiken1-5
        //Spieler bekommt Herzen abgezogen
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

        //Spieler bekommt Herzen abgezogen
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
        //Wenn der Spieler 3 Diamanten hat und beim Ziel ist wird die nächste Scene geladen
        if (diamantValue == 3 && other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("SecondLevel");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }
        //Wenn der Spieler keine 3 Diamanten hat und beim Ziel ist, wird er zurück zum Start gesetzt
       else if (other.gameObject.CompareTag("Finish") && diamantValue <= 2)
        {
            makeEnable1();
            //muss die Taste "w" drücken um zurückgesetzt zu werden
            if (Input.GetKeyDown("w"))
            {
                //Werte des Startpunkts
                transform.position = new Vector3(-10, 2, 0);
                makeDisable1();
            }
        }

        
        //Wenn der Spieler mehr als 2 Diamanten hat und im 2 Level im Ziel ist, erscheint das Menü
        if (diamantValue > 2 && other.gameObject.CompareTag("FinishSecondLevel"))
        {

            SceneManager.LoadScene("menü");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }
        //Wenn der Spieler weniger als 2 Diamanten hat und im 2 Level im Ziel ist, wird er zum Startpunkt transportiert
        else if (other.gameObject.CompareTag("FinishSecondLevel") && diamantValue <= 2)
        {
            makeEnable1();

            if (Input.GetKeyDown("w"))
            {

                transform.position = new Vector3(0, -1, 0);
                makeDisable1();
            }
        }

       
        //Abfrage ob er das Schild berührt
        if (other.gameObject.CompareTag("signrun"))
        {
            //Gravitation wird auf 1 gesetzt
            _rigidbody.gravityScale = 1;
            //Der Endgegner startet
            _endgegner.Update();
            _endgegner.gegnerstart = true;
           
        }
        //Prüfen ob die Bullets den Player treffen
        if (other.gameObject.CompareTag("Bullet"))
        {
            herz = 4;
            //Abfrage ob er noch Leben hat
            if (herz > 0)
            {

                zähler = zähler + 1;
                herz = herz - zähler;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Cmovement My_Cmovement = new Cmovement(herz, zähler);

            }
            //Abfrage ob er kein Leben mehr hat
            if (herz == 1)
            {
                SceneManager.LoadScene("Menü");

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);


            }


        }


        //Diamant werden deaktiviert und der diamantenCounter wird erhöht
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
        //Abfrage ob der Endgegner den Spieler berührt --> Leben abzug
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
            //abfrage ob er kein Leben mehr hat
            if (herz == 1)
            {
                SceneManager.LoadScene("Menü");

                herz = 4;
                zähler = 0;
                Cmovement My_Cmovement = new Cmovement(herz, zähler);


            }

        }

        //Gravitation wird geändert
        if (other.gameObject.CompareTag("gravitationänderung"))
        {
            _rigidbody.gravityScale = 3;
        }

        //Wenn er 3 diamanten hat und beim Ziel ist erscheint das Menü
        if (diamantValue == 3 && other.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene("menü");
            herz = 4;
            zähler = 0;
            Cmovement My_Cmovement = new Cmovement(herz, zähler);
        }
        //Wenn der Spieler weniger als 2 Diamanten hat, wird er zum Startpunkt transportiert
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

//Konstruktor
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