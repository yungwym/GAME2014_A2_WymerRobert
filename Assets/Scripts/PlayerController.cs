using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundRadius;
    public LayerMask groundLayerMask;
    [Range(0.1f, 0.9f)]
    public float airControlFactor;

    [Header("Animation")]
    public PlayerAnimationStates state;


    [Header("Player Variables")]
    public int playerLives = 0;
    public int playerScore = 0;
    public int playerKeys = 0;
    public int playerCoins = 0;

    private Rigidbody2D rigidbody;
    private Animator playerAnimator;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {
         float x = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * sensitivity;

        if (isGrounded)
        {
            //Keyboard Input
            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) * sensitivity;
            float jump = (Input.GetAxisRaw("Jump") + ((UIController.jumpButtonDown) ? 1.0f : 0.0f));

            // jump activated
            if (jump > 0)
            {
                audioManager.Play("PlayerJump");
            }

            // Check for Flip
            if (x != 0)
            {
                x = FlipAnimation(x);
                playerAnimator.SetInteger("AnimationState", (int)PlayerAnimationStates.WALK); // RUN State
                state = PlayerAnimationStates.WALK;
              //  CreateDustTrail();
            }
            else
            {
                playerAnimator.SetInteger("AnimationState", (int)PlayerAnimationStates.IDLE); // IDLE State
                state = PlayerAnimationStates.IDLE;
            }

            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce;

            float mass = rigidbody.mass * rigidbody.gravityScale;

            rigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            rigidbody.velocity *= 0.99f; // scaling / stopping hack
        }
        else // Air Control
        {
            playerAnimator.SetInteger("AnimationState", (int)PlayerAnimationStates.JUMP); // JUMP State
            state = PlayerAnimationStates.JUMP;

            if (x != 0)
            {
                x = FlipAnimation(x);

                float horizontalMoveForce = x * horizontalForce * airControlFactor;
                float mass = rigidbody.mass * rigidbody.gravityScale;

                rigidbody.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);
            }
           // CreateDustTrail();
        }
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;
    }

    private float FlipAnimation(float x)
    {
        // depending on direction scale across the x-axis either 1 or -1
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }


    //PLAYER FUNCTIONS 
    public int GetLives()
    {
        return playerLives;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddToScore(int amount)
    {
        playerScore += amount;
    }

    public void TakeDamage()
    {
        audioManager.Play("DamagerTaken");
        playerLives -= 1;
    }

    public void CollectCoin()
    {
        audioManager.Play("CoinPickup");
        playerCoins += 1;
    }

    public void CollectKey()
    {
        audioManager.Play("KeyPickup");
        playerKeys -= 1;
    }

    public int GetCoins()
    {
        return playerCoins;
    }

    public int GetKey()
    {
        return playerKeys;
    }


    //EVENTS 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            CollectCoin();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Key"))
        {
            CollectKey();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    // UTILITIES
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }
}