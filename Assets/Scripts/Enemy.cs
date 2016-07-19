using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public LayerMask enemyMask;
    public LayerMask otherMask;
    Transform myTrans;
    Rigidbody2D mybody;
    float MyWidth;
    public float speed;
    // Use this for initialization
    void Awake()
    {
        Health = 100;
        myTrans = this.transform;
        mybody = this.GetComponent<Rigidbody2D>();
        MyWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Health -= 50;
            if(Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * MyWidth;
        Vector2 lineCastPos2 = myTrans.position - myTrans.forward * MyWidth;

        bool isColliding = Physics2D.Linecast(lineCastPos2, lineCastPos2 - Vector2.right, enemyMask);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);

        if (!isGrounded)
        {
            Flip();
        }
        if (isColliding)
        {
            Flip();
        }

        //Always moves forward
        Vector2 myVel = mybody.velocity;
        myVel.x = -myTrans.right.x * speed;
        mybody.velocity = myVel;
    }

    void Flip()
    {
        Vector3 currRot = myTrans.localScale;
        currRot.x *= -1;
        myTrans.localScale = currRot;
        speed *= -1;
    }
}
