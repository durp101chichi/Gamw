using UnityEngine;

public class checkProfile : MonoBehaviour
{
    [SerializeField] private Animator portraitAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            portraitAnimator.Play("door_anoyed");
            Debug.Log("Playing door_look animation");
        }
    }
}
