using UnityEngine;

public class EChangeScene : MonoBehaviour
{
    [SerializeField] private SceneChange SceneChange;
    [SerializeField] private int Scene;
    [SerializeField] private GameObject E;
    private bool inRange;

    private void Start()
    {
        inRange = false;
        E.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(false);
            inRange = false;   
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            SceneChange.ChangeScene(Scene);
        }
    }
}
