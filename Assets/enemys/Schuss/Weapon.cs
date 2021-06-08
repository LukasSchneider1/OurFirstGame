using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
   

    private void Start()
    {
        Test();
       
    }
    private void Test()
    {
        //timer
        StartCoroutine(Timer());
    }


  
    IEnumerator Timer()
    {
        //jede 1,5 sekunden schießt der gegner
        yield return new WaitForSeconds((float)1.5);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       
        Start();
    }
}
