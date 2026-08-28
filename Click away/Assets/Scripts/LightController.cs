using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light Light;
    [SerializeField] private GameObject lighting;
    [SerializeField] public LightAdder LightAdder;
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
        if (LightAdder.haveLight ==true) 
        {
            if (Input.GetKeyDown(KeyCode.F))
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

       
    
}
