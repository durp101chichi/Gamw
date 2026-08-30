using ak;
using UnityEngine;

public class HasLighter : MonoBehaviour
{
    public bool hasLigher= false;
    [SerializeField] GameObject Image;
    
    private void Start()
    {
        hasLigher = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           hasLigher = true;
            Image.SetActive(true);
           
        }
    }

}
