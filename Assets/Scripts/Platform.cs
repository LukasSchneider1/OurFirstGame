using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //wo sich das gameobject hin bewegen soll
    public Transform pos1, pos2; 
    //geschwindigkeit
    public float speed;
    //startposition
    public Transform startPos;

    //nächster Punkt
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Wenn der Punkt1 erreicht wurde, bewegt es sich zum Punkt 2
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        //Wenn der Punkt2 erreicht wurde, bewegt es sich zum Punkt 1
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        //Code, dass sich das gameobject bewegt
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OndrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
