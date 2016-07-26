using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour 
{
    [SerializeField]
    GameObject sceneChange;

    void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                StartCoroutine(WaitThenLoad());                
                break;
        }
    }

    IEnumerator WaitThenLoad()
    {
        Destroy(Instantiate(sceneChange, new Vector3(transform.position.x, transform.position.y - 10f), Quaternion.identity), 3f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level Select");        
    }
}