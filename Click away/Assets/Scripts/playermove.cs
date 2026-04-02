using JetBrains.Annotations;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField]float jumpforce = 10f;
    bool isJUmping = false;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, 0f, vetical);
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
        if (Input.GetButtonDown("Jump") &&  !isJUmping)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isJUmping=true;
        }
        Application.Quit();
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
