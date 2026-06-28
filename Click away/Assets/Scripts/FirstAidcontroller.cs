using TMPro;
using UnityEngine;

public class FirstAidcontroller : MonoBehaviour
{
    [SerializeField] private int _giveHp = 25;
    [SerializeField] public PlayerDamage playerDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDamage.hp += _giveHp;
            Debug.Log("dasd");
            playerDamage.textMeshPro.text = $"Hp: {playerDamage.hp}";
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
