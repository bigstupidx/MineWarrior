using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	//ShootingStuff
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 500;
    public float yValue = 1f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0.2f; // Same as above
    //PlayerHealth
    public float PlayerHealth;
	//Movement Stuff
	private Rigidbody2D myRb;
	public float speed;
	private bool jump;
	private bool facingright;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	private bool IsGrounded;
	[SerializeField]
	private float JumpForce;
	public float bspeed;
	public Canvas PressE;
	// Use this for initialization
	void Start () {
		facingright = true;
		myRb = GetComponent<Rigidbody2D>();
		PressE.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Shooting
		 if(Time.time >= coolDown)
         {
             if(Input.GetMouseButton(0))
             {
                 Fire();
             }
         }
		//movement
		if(Input.GetKeyDown(KeyCode.W)){
			jump = true;
		}

		IsGrounded = isGrounded();

		float horizontal = Input.GetAxis("Horizontal");

		HandleMovement(horizontal);

		flip(horizontal);

	 	if(PlayerHealth <= 0){
		Destroy(gameObject);
		Application.LoadLevel("Death");	
	}
	}

	private void HandleMovement(float horizontal)
	{
		myRb.velocity = new Vector2(horizontal * speed, myRb.velocity.y);

		if(IsGrounded && jump){
			IsGrounded = false;
			myRb.AddForce(new Vector2(0, JumpForce));

		}else{
			IsGrounded = false;
			jump = false;
		}
	}
	
	private void flip(float horizontal)
	{
		if(horizontal > 0 && !facingright || horizontal < 0 && facingright)
		{
				facingright = !facingright;

				Vector3 theScale = transform.localScale;

				theScale.x *= -1;

				transform.localScale = theScale;
		}
	}
	private bool isGrounded(){
		if(myRb.velocity.y <= 0)
		{
			foreach(Transform point in groundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for(int i = 0; i < colliders.Length; i++){
					if(colliders[i].gameObject != gameObject){
						return true;

					}
				}
			}
		}
		return false;
	}
	 void Fire()
     {
     	if(facingright == true){
     		Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue, transform.position.z), Quaternion.identity) as Rigidbody2D;
     		bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
     		coolDown = Time.time + attackSpeed;
     	}
     	if(facingright == false){
     		Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue, transform.position.z), Quaternion.identity) as Rigidbody2D;
     		bPrefab.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
     		coolDown = Time.time + attackSpeed;
     	}
         //Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;
 		
       
 
         
     }
}
