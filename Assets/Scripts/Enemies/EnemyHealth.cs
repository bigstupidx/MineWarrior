using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float Health;

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
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
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
        }
    }
}