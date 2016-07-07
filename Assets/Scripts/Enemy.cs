using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public LayerMask enemyMask;
    Transform myTrans;
    Rigidbody2D mybody;
    float MyWidth;
    public float speed;
    // Use this for initialization
    void Start()
    {
        Health = 20;
        myTrans = this.transform;
        mybody = this.GetComponent<Rigidbody2D>();
        MyWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * MyWidth;
        Debug.DrawLine(lineCastPos, lineCastPos - Vector2.up);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);

        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        //Always moves forward
        Vector2 myVel = mybody.velocity;
        myVel.x = -myTrans.right.x * speed;
        mybody.velocity = myVel;
    }
}
