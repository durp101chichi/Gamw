using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.OSX;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject TargerPlayer;
    private Animator animator;
    private void Update()
    {
        agent.SetDestination(TargerPlayer.transform.position);
        //animator.SetBool()
    }







}
