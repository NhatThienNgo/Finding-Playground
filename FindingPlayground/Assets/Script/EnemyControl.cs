using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float Speed;
    private bool playerDetected;
    public BoxCollider2D BoxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == PointB.transform)
            {
                rb.velocity = new Vector2(Speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-Speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
            {
                flip();
                currentPoint = PointA.transform;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
            {
                flip();
                currentPoint = PointB.transform;
            }
   
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BoxCollider2D.isTrigger = true;
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.takeDmg(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BoxCollider2D.isTrigger = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

   
}
