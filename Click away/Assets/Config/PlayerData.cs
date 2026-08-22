using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
     [field:SerializeField]  public float money { get; set; }
    [field:SerializeField] public float bulletSpeed { get;set; }
    [field:SerializeField]  public float ArrowSpeed { get; set; }
    [field: SerializeField] public float arrowCurrentDamage { get; set; }



}
