using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour
{
    [SerializeField]
    GameObject _explosion;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Boom();
        }
    }

    public void Boom()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 6f);
        for (int i = 0; i < colliders.Length; i++)
        {
            switch (colliders[i].gameObject.tag)
            {
                case "Box":
                    colliders[i].gameObject.GetComponent<Destroyable>().Destroy();
                    break;
                case "Enemy":
                    colliders[i].gameObject.GetComponent<Destroyable>().Destroy();
                    break;
                case "Player":
                    colliders[i].gameObject.GetComponent<PlayerHealth>().TakeDamage(25f);
                    break;
            }
        }
        Destroy(Instantiate(_explosion, gameObject.transform.position, Quaternion.identity), 3);
        Destroy(this.gameObject);
    }
}