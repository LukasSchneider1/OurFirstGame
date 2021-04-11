using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevelPlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    public Animator animator;
    public AudioSource footstep;
    public AudioSource jumpsound;

    private static int herz = 4;
    private static int zähler;
   // CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);

    public int diamantValue = 0;

    //public GameObject canvasObject;
    //public GameObject canvasObject1;

    private void Start()
    {
        //makeDisable1();
        _rigidbody = GetComponent<Rigidbody2D>();
        //GameObject.FindGameObjectWithTag("moreDiamants").SetActive(false);

        //for (int i = herz; herz > 0; i--)
        //{
        //    GameObject.FindGameObjectWithTag("Herz" + i).SetActive(false);
        //    //GameObject.FindGameObjectWithTag("Herz" + (My_CmovementLvl2.iherz-My_CmovementLvl2.izähler)).SetActive(false);
        //    break;
        //}
        //if (herz == 2)
        //{
        //    GameObject.FindGameObjectWithTag("Herz3").SetActive(false);
        //}

    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            //animator.SetBool("IsJumping", true);
            jump = true;



        }

        //if (Input.anyKey || herz < 4)
        //{
        //    makeDisable();
        //}
    }

    //public void OnLanding()
    //{
    //    animator.SetBool("IsJumping", false);
    //}
    //Update is called once per frame
    private void FixedUpdate()
    {
        ////hier muss dass letzte "false" auf "jump" geändert werden!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;


    }
}

//private void Footstep()
//{
//    footstep.Play();
//}
//private void Jump()
//{
//    jumpsound.Play();
//}
//public void makeDisable1()
//{
//    canvasObject1.SetActive(false);
//}

//public void makeDisable()
//{
//    canvasObject.SetActive(false);

//}

//public void makeEnable1()
//{
//    canvasObject1.SetActive(true);
//}


//private void OnCollisionEnter2D(Collision2D other)
//{
//    //Platform selber x-Wert
//    if (other.gameObject.CompareTag("Platform"))
//    {
//        this.transform.parent = other.transform;
//    }

//    //Enemy wird augeschaltet
//    if (other.gameObject.CompareTag("Enemy"))
//    {

//        GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
//        Destroy(GameObject.FindGameObjectWithTag("Bullet"));
//        Destroy(GameObject.FindGameObjectWithTag("BulletLeft"));
//    }
//    //Player bekommt vom ersten Gegner schaden
//    if (other.gameObject.CompareTag("Enemy_schaden"))
//    {
//        herz = 4;

//        if (herz > 0)
//        {

//            zähler = zähler + 1;
//            herz = herz - zähler;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//            CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);

//        }



//    }

//    //Enemy1 wird augeschaltet
//    if (other.gameObject.CompareTag("Enemy1"))
//    {

//        GameObject.FindGameObjectWithTag("Enemy1").SetActive(false);
//        Destroy(GameObject.FindGameObjectWithTag("Bullet"));
//        Destroy(GameObject.FindGameObjectWithTag("BulletLeft"));


//    }
//    //Player bekommt vom ersten Gegner1 schaden
//    if (other.gameObject.CompareTag("Enemy_schaden1"))
//    {


//        herz = 4;

//        if (herz > 0)
//        {
//            zähler = zähler + 1;
//            herz = herz - zähler;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//            CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);
//        }

//    }
//    if (other.gameObject.CompareTag("Falldown"))
//    {
//        herz = 4;
//        if (herz > 0)
//        {
//            zähler = zähler + 1;
//            herz = herz - zähler;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//            CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);
//        }

//    }

//    //Prüfen ob die Bullets den Player treffen
//    if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BulletLeft"))
//    {
//        herz = 4;

//        if (herz > 0)
//        {

//            zähler = zähler + 1;
//            herz = herz - zähler;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//            CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);

//        }



//    }
//    //Spiken1-2
//    if (other.gameObject.CompareTag("Spike1") || other.gameObject.CompareTag("Spike2") || other.gameObject.CompareTag("Spike3") || other.gameObject.CompareTag("Spike4") || other.gameObject.CompareTag("Spike5"))
//    {
//        herz = 4;

//        if (herz > 0)
//        {

//            zähler = zähler + 1;
//            herz = herz - zähler;
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//            CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);

//        }



//    }

//    //Abfrage ob er noch ein leben hat
//    if (herz == 1)
//    {
//        Application.LoadLevel("Menü");

//        herz = 4;
//        zähler = 0;
//        CmovementLvl2 My_CmovementLvl2 = new CmovementLvl2(herz, zähler);


//    }

//    if (other.gameObject.CompareTag("door"))
//    {

//        GameObject.FindGameObjectWithTag("moreDiamants").SetActive(true);
//        print("zuwenig");

//    }

//    //Diamant
//    if (other.gameObject.CompareTag("Diamant"))
//    {

//        GameObject.FindGameObjectWithTag("Diamant").SetActive(false);
//        ScoreManager.instance.ChangeScore(diamantValue);
//        diamantValue++;
//    }

//    if (other.gameObject.CompareTag("Diamant2"))
//    {

//        GameObject.FindGameObjectWithTag("Diamant2").SetActive(false);
//        ScoreManager.instance.ChangeScore(diamantValue);
//        diamantValue++;
//    }

//    if (other.gameObject.CompareTag("Diamant3"))
//    {

//        GameObject.FindGameObjectWithTag("Diamant3").SetActive(false);
//        ScoreManager.instance.ChangeScore(diamantValue);
//        diamantValue++;
//    }

//    if (other.gameObject.CompareTag("Diamant4"))
//    {

//        GameObject.FindGameObjectWithTag("Diamant4").SetActive(false);
//        ScoreManager.instance.ChangeScore(diamantValue);
//        diamantValue++;
//    }




//}

//private void OnCollisionExit2D(Collision2D other)
//{

//    if (other.gameObject.CompareTag("Platform"))
//    {
//        this.transform.parent = null;

//    }
//}

//private void OnTriggerStay2D(Collider2D other)
//{
//    if (other.gameObject.CompareTag("Finish") && diamantValue <= 2)
//    {
//        makeEnable1();

//        if (Input.GetKeyDown("w"))
//        {

//            transform.position = new Vector3(-10, 2, 0);
//            makeDisable1();
//        }
//    }

//    else if (diamantValue > 2 && other.gameObject.CompareTag("Finish"))
//    {
//        print("genug Diamonds");
//    }

//}



//}
//[SerializeField()]
//public class CmovementLvl2
//{
//    private int _herz;

//    public int iherz
//    {
//        get { return _herz; }
//        set { _herz = value; }
//    }

//    private int _zähler;

//    public int izähler
//    {
//        get { return _zähler; }
//        set { _zähler = value; }
//    }


//    public CmovementLvl2(int herzk, int zählerk)
//    {
//        _herz = herzk;
//        _zähler = zählerk;
//    }


//}
