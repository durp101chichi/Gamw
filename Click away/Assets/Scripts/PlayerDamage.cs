using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDamage : MonoBehaviour
{
    [SerializeField] public float hp;
    [SerializeField] public float maxHp;
    [SerializeField] public TextMeshProUGUI textMeshPro;
    [SerializeField] public Slider Slider;
    [SerializeField] private GameObject bloodImage;
    [SerializeField] private GameObject bloodImage1;
   
    void Start()
    {
        Slider.maxValue = maxHp;
        Slider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 50)
        {
            bloodImage.SetActive(true);
            bloodImage1.SetActive(false);
        }
        if (hp > 50 && hp < 80)
        {
            bloodImage.SetActive(false);
            bloodImage1.SetActive(true);
        }
        if (hp > 80)
        {
            bloodImage1.SetActive(false);
            bloodImage.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            hp -= 20;
            Slider.value = hp;
            textMeshPro.text = $" {hp}";
        }

        // Or access the impact velocity
        
    }
   
  
}
