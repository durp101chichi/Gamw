using UnityEngine;

[CreateAssetMenu(fileName = "EnemySunData", menuName = "Scriptable Objects/EnemySunData")]
public class EnemySunData : ScriptableObject
{
    [SerializeField] public float sunspeed;
    //[SerializeField] float  public Transform[] targets;
    [SerializeField] public float duration = 5f; 
    [SerializeField] public Transform target;
    
}
