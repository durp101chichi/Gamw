using UnityEngine;

public class KickScript : MonoBehaviour
{
    Animator animator;
    private void Update()
    {
        animator = GetComponent<Animator>();
        Kick();
    }
    private void Kick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("kick");
        }
        else
        {
            animator.ResetTrigger("kick");
        }
        
    }
}
