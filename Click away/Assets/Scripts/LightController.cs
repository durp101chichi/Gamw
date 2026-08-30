using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light Light;
    [SerializeField] private GameObject lighting;
    [SerializeField] private HasLighter HasLighter;
    private bool isActive = true;
    void Start()
    {
        Light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        lightOn();
        

    }
    

    private void lightOn()
    {
        if (Input.GetKeyDown(KeyCode.F) && HasLighter.hasLigher == true)
        {
            
            if (isActive) 
            {
                Light.intensity = 100;
                isActive = false;
                lighting.SetActive(true);
            }

            else
            {
                isActive = true;
                Light.intensity = 0;
                lighting.SetActive(false);
            }
            
        }
    }
    
}
