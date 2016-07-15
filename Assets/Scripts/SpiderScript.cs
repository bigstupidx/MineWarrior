using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-Vector2.up, 100.3F);
        if(hit == true)
        {
            if(hit.collider.tag == "Player")
            {
                Debug.Log("Hit");
                anim.SetBool("spiderAttack", true);
                StartCoroutine("SetBoolFalse");
            }
        }
    }

    IEnumerator SetBoolFalse()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("spiderAttack", false);
    }


}
