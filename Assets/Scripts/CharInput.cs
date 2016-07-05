using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharController))]
public class CharInput : MonoBehaviour 
{
    private CharController Character;
    private bool Jump;
    private bool Shoot;

    void Awake() 
	{
        Character = GetComponent<CharController>();
    }
 
    void Update() 
	{
        if(!Jump)
        {
            Jump = Input.GetButtonDown("Jump");
        }
        if(!Shoot)
        {
            Shoot = Input.GetButtonDown("Fire1");
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Character.TakeInput(h, Jump, Shoot);
        Jump = false;
        Shoot = false;
    }
}