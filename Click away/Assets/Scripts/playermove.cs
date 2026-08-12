using JetBrains.Annotations;
using UnityEngine;
using System.Collections;

public class Playermove : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField]float jumpforce = 10f;
    [SerializeField] float dashForce = 2000f;
    [SerializeField] float rotationSpeed;
    bool isGrounded;
    bool canDash = true;
    Rigidbody rb;
    Animation AnimationController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, 0f, vetical);
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);



        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        Jump();
        Dash();
  //    Dive();
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

        }
    }
 // public void Dive()
 // {
   //   if (Input.GetKeyDown(KeyCode.LeftAlt) && !isGrounded)
   //   {
   //       rb.AddForce(Vector3.down * jumpforce, ForceMode.VelocityChange);
   //   }
//  }
    
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash)
        {
           
            StartCoroutine(DashCooldownLeft());
        }
       // if (Input.GetKeyDown(KeyCode.LeftAlt) && canDash)
        //{
        //    StartCoroutine(DashCooldownRight());
       // }
    }
    private IEnumerator DashCooldownLeft()
    {
        canDash = false;

        rb.AddForce(Vector3.left * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(6f);

        canDash = true;
    }
    IEnumerator DashCooldownRight()
    {
        canDash = false;

        rb.AddForce(Vector3.right * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(6f);

        canDash = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
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
