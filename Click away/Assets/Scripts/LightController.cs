using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light Light;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (isActive) 
            {
                Light.intensity = 1000;
                isActive = false;
            }

            else
            {
                isActive = true;
                Light.intensity = 0;
            }
            
        }
    }
    
}
