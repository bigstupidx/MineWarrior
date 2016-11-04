using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharController))]
public class CharInput : MonoBehaviour 
{
    private CharController Character;
    private bool Jump;
    public bool Shoot;
    public bool Throw;

    public GameObject buttonControls;

    void Awake() 
	{
        Character = GetComponent<CharController>();
        buttonControls = GameObject.Find("Buttons");
    }


#if UNITY_IOS || UNITY_ANDROID

    void Start()
    {
        buttonControls.SetActive(true);
    }

    private float h;

    public void buttonLeft()
    {
        h = -1;
    }

    public void buttonRight()
    {
        h = 1;
    }

    public void buttonReleased()
    {
        h = 0;
    }

    public void buttonJump()
    {
        Jump = true;
    }

    public void buttonShoot()
    {
        Shoot = true;
    }

    public void shootRelease()
    {
        Shoot = false;
    }

    public void throwGrenade()
    {
        Throw = true
    }

    private void FixedUpdate()
    {
        Character.TakeInput(h, Jump, Shoot, Throw);

        Jump = false;
        Throw = false;
    }


#elif UNITY_EDITOR || UNITY_STANDALONE_WIN

    void Start()
    {
        buttonControls.SetActive(false);
    }

    void Update() 
	{
        if(!Jump)
        {
            Jump = Input.GetButtonDown("Jump");
        }
        if(!Shoot)
        {
            Shoot = Input.GetButton("Fire1");
        }
        if(!Throw)
        {
            Throw = Input.GetButton("Fire2");
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Character.TakeInput(h, Jump, Shoot, Throw);
        Jump = false;
        Shoot = false;
        Throw = false;
    }
#endif
}