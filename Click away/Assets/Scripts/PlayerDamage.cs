using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] public int hp;
    [SerializeField] public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            hp -= 20;
            textMeshPro.text = $"Hp: {hp}";
        }

        // Or access the impact velocity
        
    }
    private void Damage()
    {
        
    }
   // private void OnTriggerEnter(Collider other)
  //  {
     //   if (other.CompareTag("Enemy"))
    //    {
     //       hp = 200 - 10;
      //  }
   // }
}
