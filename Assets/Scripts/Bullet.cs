using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Bullet : MonoBehaviour {
    // Use this for initialization
    void Start () {
    }
   
    // Update is called once per frame
    void Update () {
       
    }  
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            Enemy em = col.gameObject.GetComponent<Enemy>();
            em.Health -= 5f;
            Debug.Log("Hut");
            Destroy(gameObject);
        }
}
}