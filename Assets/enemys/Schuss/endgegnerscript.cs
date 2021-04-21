using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgegnerscript : MonoBehaviour
{
    public bool run;
    public SpriteRenderer _spriterenderer;
    public movement _movement;
    public Transform pos1, pos2;
    private float speed = 5;
    public Transform startPos;
    public bool gegnerstart = false; //aktiviert den endgegner
    
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        if(gegnerstart == false)
        {
            this.gameObject.SetActive(false);
        }
        this.transform.position = new Vector3(95, 0, 0);
        nextPos = startPos.position;
        
      
    }

    // Update is called once per frame
   
    public void Update()
    {
       
        this.gameObject.SetActive(true);
      
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            _spriterenderer.flipX = false;

        }

        if (transform.position == pos1.position)
        {
            gegnerstart = false;
            Start(); 
            _spriterenderer.flipX = true;

        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
    public void OndrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    
        


}


