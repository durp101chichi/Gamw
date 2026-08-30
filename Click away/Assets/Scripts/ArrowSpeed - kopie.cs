using Unity.VisualScripting;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{

    [SerializeField] PlayerData _playerData;
    private void Start()
    {
        _playerData.ArrowSpeed = 20;
    }
    public void Tier1()
    {
        if (_playerData.ArrowSpeed <= 15)
        {
            _playerData.arrowCurrentDamage = 5;
            Debug.Log("5");
        }
    }
    public void Tier2()
    {
        if (_playerData.ArrowSpeed <= 30 && _playerData.ArrowSpeed > 15)
        {
            _playerData.arrowCurrentDamage = 10;
            Debug.Log("10");
        }
    }
    public void Tier3()
    {
        if (_playerData.ArrowSpeed <= 40 && _playerData.ArrowSpeed > 30)
        {
            _playerData.arrowCurrentDamage = 15;
            Debug.Log("15");
        }
    }
    public void Tier4()
    {
        if (_playerData.ArrowSpeed <= 50 && _playerData.ArrowSpeed > 40)
        {
            _playerData.arrowCurrentDamage = 20;
            Debug.Log("20");
        }
    }
    public void Tier5()
    {
        if (_playerData.ArrowSpeed <= 60 && _playerData.ArrowSpeed > 50)
        {
            _playerData.arrowCurrentDamage = 30;
            Debug.Log("30");
        }
    }
}
