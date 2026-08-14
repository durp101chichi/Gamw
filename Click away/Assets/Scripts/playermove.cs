using JetBrains.Annotations;
using UnityEngine;
using System.Collections;

public class Playermove : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField]float jumpforce = 10f;
    [SerializeField] float dashForce = 2000f;
    [SerializeField] float rotationSpeed;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] float wallSlideSpeed = 2f;
    [SerializeField] float wallRunDuration = .5f;
    [SerializeField] Vector2 sideJumpForce = new Vector2(10f, 10f);

    float directionalInput;
    float horizontal;
    bool isGrounded;
    bool wall;
    bool isFacingRight = true;
    bool isWallRunning;
    bool isWallJumping;
    bool canDash = true;
    Rigidbody rb;
    Animator animationController;
    float idleTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, 0f, vetical);

        if (dialogueManager.dialogueIsPlaying)
            rb.linearVelocity = Vector3.zero;
        else 
            rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);



        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            idleTime = 0;
            animationController.SetBool("walking", true);
        }
        else
        {
            idleTime += Time.deltaTime;
            animationController.SetBool("walking", false);
        }
        animationController.SetInteger("idleTime", (int)idleTime);


        HandleWallSliding();
        Jump();
        Dash();
     //   Dive();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                animationController.SetBool("jump", true);
            }

            if (wall)
            {
                TriggerWallJump();
                animationController.SetBool("running", true);
            }
        }
        else
        {
            animationController.SetBool("running", false);
            animationController.SetBool("jump", false);
        }
    }
  //public void Dive()
  //{
  //    if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded)
  //    {
  //       rb.AddForce(Vector3.down * jumpforce, ForceMode.VelocityChange);
  //    }
  //}
    
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(DashCooldown());
        }
    }
    private IEnumerator DashCooldown()
    {
        canDash = false;
        animationController.SetTrigger("dash");

        if (horizontal >= 0)
            rb.AddForce(Vector3.right * dashForce, ForceMode.VelocityChange);
        else if (horizontal < 0)
            rb.AddForce(Vector3.left * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(.5f);

        canDash = true;
        animationController.ResetTrigger("dash");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        if (collision.gameObject.CompareTag("Wall"))
            wall = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
        if (collision.gameObject.CompareTag("Wall"))
            wall = false;
    }

    private void TriggerWallJump()
    {
        isWallJumping = true;
        isWallRunning = false;

        directionalInput = isFacingRight ? 1f : -1f;

        rb.linearVelocity = new Vector3(sideJumpForce.x, sideJumpForce.y);

        if ((directionalInput > 0 && !isFacingRight) || (directionalInput < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        Invoke(nameof(StopWallJumping), wallRunDuration);
    }

    private void HandleWallSliding()
    {
        // Slide if touching a wall in mid-air while pressing toward it
        if (wall && !isGrounded && horizontal != 0f)
        {
            isWallRunning = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallRunning = false;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    //private void OnCollisionEnter(Collision collision)
    //{

    //   if (collision.gameObject.CompareTag("Ground"))
    //   {
    //      isJUmping=false;
    //      Application.Quit();
    //     Debug.Log("touch the object!!!!");
    //      Application.Quit();
#if UNITY_EDITOR
    //    UnityEditor.EditorApplication.isPlaying = false;
#endif
    // }


    // }

}
