using UnityEngine;
using System.IO;
using System.Collections;
namespace ak
{
    public class HasAk : MonoBehaviour
    {
        public bool hsAk = false;
        [SerializeField] GameObject Image;
        [SerializeField] public GameObject ak1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hsAk = true;
                Image.SetActive(true);
                ak1.SetActive(true);
            }
        }
    }
}


