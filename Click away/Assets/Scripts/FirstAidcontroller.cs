using TMPro;
using UnityEngine;

public class FirstAidcontroller : MonoBehaviour
{
    [SerializeField] private int _giveHp = 50;
    [SerializeField] public PlayerDamage playerDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerDamage.hp >= 200)
            {
                playerDamage.hp = 200;
            }
            playerDamage.hp += _giveHp;
            playerDamage.Slider.value = playerDamage.hp;
            
            playerDamage.textMeshPro.text = $" {playerDamage.hp}";

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
