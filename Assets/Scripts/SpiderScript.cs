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
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector3.down);
        if(hit == true)
        {
            if(hit.collider.tag == "Player")
            {
                anim.SetBool("spiderAttack", true);
                StartCoroutine("SetBoolFalse");
            }
        }
    }

    IEnumerator SetBoolFalse()
    {
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("spiderAttack", false);
    }


}
