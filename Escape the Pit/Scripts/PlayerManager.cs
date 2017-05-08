using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Gabriel Petkac, Nick Krotine, Jae Son
public class PlayerManager : MonoBehaviour {
    private Rigidbody2D rb2d;

    private Animator anim;

	[SerializeField]
	private GameObject player;

    [SerializeField]
	private float movementSpeed;
    private bool facingRight;
    private bool jumping;
    private bool isGrounded;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

	//cache
	private AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        facingRight = true;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
		//cache
		audioManager = AudioManager.instance;
		if (audioManager == null) 
		{
			Debug.LogError ("Freak out there is no AuidioManager found in the scene!!!");
		}
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        Flip(horizontal);

        ResetValues();

		won ();
		died ();
    }

   void Update()
    {
        AnimationManager();
		if (anim.Equals("1"))
		{
			print ("runcode");
			audioManager.PlaySound ("Footstep");
		}
	
    }

    private void HandleMovement(float horizontal)
    {
        if(isGrounded || airControl)
        {
            rb2d.velocity = new Vector2(horizontal * movementSpeed, rb2d.velocity.y);
        }

        if (isGrounded && jumping)
        {
            isGrounded = false;
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
        //anim.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        jumping = false;
    }

   
    private bool IsGrounded()
    {
        if(rb2d.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    
    void AnimationManager()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetBool("IsJumping", true);
			audioManager.PlaySound ("Jump");
            jumping = true;
            
		}

        if (Input.GetKeyUp(KeyCode.Space) )
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("touchdown", true);
            jumping = false;
			//landed noise if wanted
        }


        //Handling the idle to walking to idle state change
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) )
        {
            anim.SetFloat("State", 1); 
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("State", 0);
        }
    }

	void won()
	{
		if (player.transform.position.y > 28)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex+1);
		}
	}
	void died()
	{
		if (player.transform.position.y < -5)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}
}
