using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ArrowShoter : MonoBehaviour
{
    public GameObject pijlPrefab;    //arrowprefab
    public Transform schietPunt;     //shootpoint
    [SerializeField] PlayerData PlayerData;
    
    [SerializeField] int ammountOfShoot;
    public float arrowspeed;
    [SerializeField] TextMeshProUGUI arrowCounter;
    [SerializeField] AkController akController;
    [SerializeField] HasAk hasAk;
    [SerializeField] ArrowDamage arrowSpeed;
    [SerializeField] PauseMenuActivate pauseMenuActivate;
    
    [Header("Scroll Instellingen")]

    public float scrollGevoeligheid = 1f; //scroolsens
    public float minimaleSnelheid = 0f;  //minspeed
    public float maximaleSnelheid = 60f; //maxspeed

    private void Start()
    {


        arrowCounter.text = $"{ammountOfShoot}";
    }
    void Update()
    {
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            PasSnelheidAan(scroll);
        }
        if (Input.GetMouseButtonDown(0) && !hasAk.hasAk)
        {
          //  if (pauseMenuActivate.isPaused == false)
            {
                if (ammountOfShoot > 0)
                {
                    SchietPijlNaarMuis();
                    ammountOfShoot--;
                    arrowCounter.text = $"{ammountOfShoot}";
                    arrowSpeed.Tier1();
                    arrowSpeed.Tier2();
                    arrowSpeed.Tier3();
                    arrowSpeed.Tier4();
                    arrowSpeed.Tier5();
                    SpeedDrop();
                }
            } 
            
        }
    }
    void PasSnelheidAan(float scrollRichting)
    {
       
        PlayerData.ArrowSpeed += scrollRichting * scrollGevoeligheid;

        
        PlayerData.ArrowSpeed = Mathf.Clamp(PlayerData.ArrowSpeed, minimaleSnelheid, maximaleSnelheid);

       
    }
    void SchietPijlNaarMuis()
    {
       
        Plane speelvlak = new Plane(-Camera.main.transform.forward, schietPunt.position);
        Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (speelvlak.Raycast(straal, out float afstand))
        {
            Vector3 muisPositie = straal.GetPoint(afstand);
            Vector3 richtingsVector = muisPositie - schietPunt.position;
            richtingsVector.z = 0f;
            if (richtingsVector == Vector3.zero) return;
            Quaternion pijlRotatie = Quaternion.LookRotation(richtingsVector, Vector3.up);   
            GameObject nieuwePijl = Instantiate(pijlPrefab, schietPunt.position, pijlRotatie);
           Collider pijlCol = nieuwePijl.GetComponent<Collider>();
            Collider spelerCol = GetComponent<Collider>();
            if (pijlCol != null && spelerCol != null)
            {
                Physics.IgnoreCollision(pijlCol, spelerCol);
            }
            Rigidbody rb = nieuwePijl.GetComponent<Rigidbody>();
            rb.linearVelocity = richtingsVector.normalized * PlayerData.ArrowSpeed;
            if (richtingsVector != Vector3.zero)
            {
                nieuwePijl.transform.forward = richtingsVector;
            }
        }
    }
    private void SpeedDrop()
    {
        if (PlayerData.ArrowSpeed > 0)
        {
         
            
            PlayerData.ArrowSpeed -= 5;
            
        }
        


    }

}
