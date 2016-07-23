using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour 
{
    [SerializeField]
    GameObject _explosion;
    PointEffector2D _pointEffector;
    SpriteRenderer _sprite;

    void Awake()
    {
        _pointEffector = GetComponent<PointEffector2D>();
        _pointEffector.enabled = false;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            StartCoroutine(WaitThenDestroy());
            Destroy(Instantiate(_explosion, coll.gameObject.transform.position, Quaternion.identity), 3);            
        }
    }

    IEnumerator WaitThenDestroy()
    {
        _pointEffector.enabled = true;
        _sprite.enabled = false;
        yield return new WaitForSeconds(.1f);
        Destroy(this.gameObject);
    }
}