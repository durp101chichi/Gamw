using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public Transform door;      // Объект двери
    
    public float openAngle = 90f;
    public float speed = 3f;

    private bool playerNear = false;
    private bool isOpen = false;
    private bool IsBlock = true;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = door.rotation;
        openRotation = Quaternion.Euler(
            door.eulerAngles.x,
            door.eulerAngles.y + openAngle,
            door.eulerAngles.z
        );
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        door.rotation = Quaternion.Slerp(door.rotation, targetRotation, Time.deltaTime * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = false;
    }
}
