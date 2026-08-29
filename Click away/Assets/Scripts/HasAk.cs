using UnityEngine;
using System.IO;
using System.Collections;

public class HasAk : MonoBehaviour
{
    public bool hsAk = false;
    [SerializeField] GameObject akImage;
    [SerializeField] public GameObject ak;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hsAk = true;
            ak.SetActive(true);
            akImage.SetActive(true);
        }
    }
}
