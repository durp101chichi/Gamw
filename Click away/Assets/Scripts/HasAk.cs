using UnityEngine;

public class HasAk : MonoBehaviour
{
    public bool hasAk = false;
    [SerializeField] GameObject akImage;
    [SerializeField] public GameObject ak;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasAk = true;
            ak.SetActive(true);
            akImage.SetActive(true);
        }
    }
}
