using UnityEngine;

public class LightAdder : MonoBehaviour 
{
  
    [SerializeField] private GameObject LighIcon;
    public bool haveLight = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            haveLight = true;
            LighIcon.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
