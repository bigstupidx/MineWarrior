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

    [SerializeField]
    private GameObject enemyEffect;

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
        switch (coll.gameObject.tag)
        {
            case "Bullet":
                Health -= 50;
                if (Health <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
            case "Box":
                Destroy(this.gameObject);
                Destroy(Instantiate(enemyEffect, transform.position, transform.rotation), 2f);
                break;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * MyWidth;

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);

        if (!isGrounded)
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
