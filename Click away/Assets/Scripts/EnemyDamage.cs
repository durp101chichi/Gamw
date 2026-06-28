using TMPro;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public EnemySunData EnemySunData;
    [SerializeField] public TextMeshProUGUI EnemySunHp;
    private void Update()
    {
        if (EnemySunData.hp <= 0)
        {
            gameObject.SetActive(false);
            EnemySunHp.gameObject.SetActive(false );
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemySunData.hp -= 30;
         EnemySunHp.text = $" Sun hp: {EnemySunData.hp}";
          
        }
        

    }
}
