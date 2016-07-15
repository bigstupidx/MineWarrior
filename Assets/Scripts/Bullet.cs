using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] Effects;

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                break;
            case "Box":
                Debug.Log("Box");
                Destroy(0);
                break;
            case "Enemy":
                Destroy(2);
                break;
            case "Coin":
                break;
            default:
                Destroy(1);
                break;
        }
    }

    void Destroy(int effectIndex)
    {        
        Destroy(this.gameObject);
        Destroy(Instantiate(Effects[effectIndex], transform.position, transform.rotation), 1f);
    }
}