using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.AI;
public class EnemySunMoveController : MonoBehaviour
{
    [SerializeField] private EnemySunData enemySunData;
    [SerializeField] private Transform enemySunTransform;
   
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
       
        
            navMeshAgent.SetDestination(enemySunTransform.position);
        

    }
}
