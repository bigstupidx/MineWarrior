using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour
{    
    public float x;

    public float y;

    private Rigidbody2D body2D;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        body2D.AddForce(new Vector2(x, y));
    }

}
