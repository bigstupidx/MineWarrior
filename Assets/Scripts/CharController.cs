using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour 
{
    [SerializeField]
    private float MaxSpeed = 10f;
    [SerializeField]
    private float JumpForce = 400f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform muzzleFlashPrefab;

    private Transform groundCheck;
    const float groundCheckRadius = .2f;
    private bool Grounded;
    private Rigidbody2D body2D;
    private bool facingRight = true;
    private Transform firePoint;
    private float timeToFire = 0;
    private Animator anim;

    void Awake() 
	{
        // Set up references
        groundCheck = transform.Find("GroundCheck");
        firePoint = transform.Find("FirePoint");
        body2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Grounded = false;
        anim.SetBool("Grounded", false);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
                anim.SetBool("Grounded", true);
            }
        }
    }

    public void TakeInput(float move, bool jump, bool shoot)
    {
        body2D.velocity = new Vector2(move * MaxSpeed, body2D.velocity.y);
        if(move != 0)
        {
            anim.SetBool("Walking", true);
        } else
        {
            anim.SetBool("Walking", false);
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }

        else if (move < 0 && facingRight)
        {
            Flip();
        }
        
        if(Grounded && jump)
        {
            Grounded = false;
            body2D.AddForce(new Vector2(0f, JumpForce));
        }
        
        if(shoot)
        {
            Shoot();
        }                
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Transform clone = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);


        if (!facingRight)
        { 
            bullet.GetComponent<InstantVelocity>().velocity.x *= -1;
            Vector2 bulletScale = bullet.transform.localScale;
            bulletScale.x *= -1;
            bullet.transform.localScale = bulletScale;            
        }
        Destroy(bullet, 1f);
    }

    void Flip() 
	{
        facingRight = !facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}