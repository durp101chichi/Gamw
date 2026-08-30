using TMPro;
using UnityEngine;

public class AkController : MonoBehaviour
{
    public GameObject pijlPrefab;    //arrowprefab
    public Transform schietPunt;     //shootpoint
    
    public ParticleSystem smoke;
    [SerializeField] int ammo;
    [SerializeField] TextMeshProUGUI bulletcounter;
    [SerializeField] HasAk HasAk;
    [SerializeField] PlayerData playerData;
    [SerializeField] PauseMenuActivate menuActivate;
    [SerializeField] public bool canFire = true;


    private void Start()
    {
        bulletcounter.text = $"{ammo}";
    }
    void Update()
    {
      DraaiNaarMuis();
        DropAk();
       


        if (Input.GetMouseButtonDown(0))
        {
           // if (menuActivate.isPaused == false) 
            {
                if (HasAk.hasAk)
                {
                    if (canFire)
                    {
                        if (ammo > 0)
                        {
                            SchietPijlNaarMuis();
                            ammo--;
                            bulletcounter.text = $"{ammo}";
                        }
                    }
                    
                }
            }
                 
            
        }
    }

    void SchietPijlNaarMuis()
    {

        GameObject nieuwePijl = Instantiate(pijlPrefab, schietPunt.position, schietPunt.rotation);
        Rigidbody rb = nieuwePijl.GetComponent<Rigidbody>();

        if (rb != null)
        {
            
           // Plane speelvlak = new Plane(Vector3.forward, schietPunt.position);
          //  Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);

            
          //  float afstand;
            Vector3 vliegRichting = -transform.forward;

           // if (speelvlak.Raycast(straal, out afstand))
            {
           //     Vector3 muisOpVlak = straal.GetPoint(afstand);

               
           //     vliegRichting = muisOpVlak - schietPunt.position;
           //     vliegRichting.z = 0f; 
           //     vliegRichting.Normalize(); 
            }


            rb.linearVelocity = vliegRichting * playerData.bulletSpeed;

            if (vliegRichting != Vector3.zero)
            {
                nieuwePijl.transform.forward= vliegRichting;
               
                smoke.Play();
            }
        }
    }
    void DraaiNaarMuis()
    {
        
        Plane speelvlak = new Plane(Vector3.forward, transform.position);
        Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);

        float afstand;
        if (speelvlak.Raycast(straal, out afstand))
        {
            
            Vector3 muisPositie = straal.GetPoint(afstand);

           
            Vector3 kijkRichting = muisPositie - transform.position;
            kijkRichting.z = 0f; 

            
            if (kijkRichting != Vector3.zero)
            {
                transform.forward = kijkRichting;
            }
        }
    }
    private void DropAk()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (HasAk.hasAk)
            {
                HasAk.hasAk = false;
                HasAk.ak.SetActive(false);
               
            }
        }
       
    }

}
