using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour 
{
    [SerializeField]
    GameObject destroyEffect;

    public void Destroy()
    {
        Destroy(Instantiate(destroyEffect, transform.position, transform.rotation), 3f);
        Destroy(gameObject);
    }    
}