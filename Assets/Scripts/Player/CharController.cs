using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharController : MonoBehaviour 
{

    #region Inspector Variables
    [Header("Movement Variables")]

    [SerializeField]
    float MaxSpeed = 10f;
    [SerializeField]
    float JumpForce = 400f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    GameObject jumpEffect;

    [Header("Shooting Variables")]

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform muzzleFlashPrefab;
    [SerializeField]
    GameObject gunshotSound;

    [Header("Misc Variables")]

    [SerializeField]
    GameObject door;    
    [SerializeField]
    Text GemText;

    #endregion

    #region Private Variables

    int totalGems;
    private int collectedGems;

    // Movement

    bool doubleJump = true;
    Transform groundCheck;
    const float groundCheckRadius = .2f;
    bool Grounded;
    Rigidbody2D body2D;
    bool facingRight = true;
    Animator anim;

    // Shooting

    Transform firePoint;

    // References
    PlayerHealth healthManager;

    #endregion

    void Awake() 
	{
        // Set up references
        door = GameObject.FindGameObjectWithTag("Door");
        groundCheck = transform.Find("GroundCheck");
        firePoint = transform.Find("FirePoint");
        body2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<PlayerHealth>();
        totalGems = GameObject.FindGameObjectsWithTag("Gem").Length;
        door.SetActive(false);
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
                doubleJump = true;
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

        if (Grounded == false && doubleJump == true && jump)
        {
            doubleJump = false;
            body2D.velocity = new Vector2(body2D.velocity.x, 0);
            body2D.AddForce(new Vector2(0f, JumpForce));
            Destroy(Instantiate(jumpEffect, transform.position, transform.rotation), 1f);
        }

        if (Grounded && jump)
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
        GameObject sound = Instantiate(gunshotSound, transform.position, transform.rotation) as GameObject;
        Transform clone = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
        Destroy(sound, .6f);

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

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag) {

            case "Gem":
                Destroy(col.gameObject);                
                collectedGems++;                
                if (collectedGems == totalGems)
                {
                    door.SetActive(true);
                }
                break;
            case "Enemy":
                healthManager.TakeDamage(25f);
                break;
            default:
                break;
        }
   }

    void OnCollisionEnter2D(Collision2D col)
    {

        switch (col.gameObject.tag)
        {
            case "Spike":
                healthManager.TakeDamage(50f);
                break;
            case "Enemy":
                healthManager.TakeDamage(25f);
                break;
            default:
                break;
        }
    }
}