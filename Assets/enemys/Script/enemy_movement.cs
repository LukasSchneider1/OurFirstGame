using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyScale = transform.localScale;
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            enemyScale.x = -5;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            enemyScale.x = 5;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        transform.localScale = enemyScale;
    }

    private void OndrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("sjflsjf");
        }
    }
}
