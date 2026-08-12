using Unity.Cinemachine;
using UnityEngine;
public class CameraChange : MonoBehaviour
{
    [SerializeField] private CinemachineCamera camera1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camera1.enabled = true;
            Debug.Log("Camera 1 enabled");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camera1.enabled = false;
            Debug.Log("Camera 1 disabled");
        }
    }
}
