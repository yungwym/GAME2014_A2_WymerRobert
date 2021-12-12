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
    public LayerMask groundKayerMask;




    private Rigidbody2D rigidbody;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
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
            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) *sensitivity;
            float jump = (Input.GetAxisRaw("Jump") + joystick.Vertical) * sensitivity;
        }

    }

    private void CheckIfGrounded()
    {
     //   RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

     //   isGrounded = (hit) ? true : false;
    }


}