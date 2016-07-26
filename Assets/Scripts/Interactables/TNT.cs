using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour 
{
    [SerializeField]
    GameObject _explosion;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            Destroy(Instantiate(_explosion, coll.gameObject.transform.position, Quaternion.identity), 3);
            Destroy(this.gameObject);
        }
    }
}