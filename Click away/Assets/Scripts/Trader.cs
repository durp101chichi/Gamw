using DG.Tweening;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class Trader : MonoBehaviour
{


    [SerializeField] TraderConfig config;
    [SerializeField] PlayerData playerData;
    [SerializeField] public GameObject _uiTraderMenu;
    [SerializeField] private TextMeshProUGUI ticketText;
    [SerializeField] public TextMeshProUGUI animationText;

    private bool isAnimating = false;
    private void Start()
    {
        config.ticketAmmount = 0;
        config.leftAlphas = new float[animationText.text.Length].ToList();
        config.rightAlphas = new float[animationText.text.Length].ToList();
    }
    private void Update()
    {
        if (isAnimating)
        {
            SwitchColor();
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            isAnimating = true;
            StartCoroutine(Smooth(0));
        }
        if (Input.GetKeyUp(KeyCode.End))
        {
            isAnimating = false;
            Visible(true);
        }
    }
    private void Visible(bool visible)
    {
        StopAllCoroutines();
        DOTween.Kill(1);

        for (int i = 0; i < config.leftAlphas.Count; i++)
        {
            config.leftAlphas[i] = visible ? 255 : 0;
            config.rightAlphas[i] = visible ? 255 : 0;
        }
        SwitchColor();
    }
    
    private void SwitchColor()
    {
        for (int i = 0; i < config.leftAlphas.Count; i++)
        {
            if (animationText.textInfo.characterInfo[i].character != '\n' &&
                animationText.textInfo.characterInfo[i].character != ' ')
            {
                int meshIndex = animationText.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = animationText.textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = animationText.textInfo.meshInfo[meshIndex].colors32;

                vertexColors[vertexIndex + 0].a = (byte)config.leftAlphas[i];
                vertexColors[vertexIndex + 1].a = (byte)config.leftAlphas[i];
                vertexColors[vertexIndex + 2].a = (byte)config.rightAlphas[i];
                vertexColors[vertexIndex + 3].a = (byte)config.rightAlphas[i];
            }
        }
        animationText.UpdateVertexData();
    }
    private IEnumerator Smooth(int i)
    {
        if (i >= config.leftAlphas.Count)
            yield break;

        DOTween.To(
        () => config.leftAlphas[i],
        z => config.leftAlphas[i] = z,
        255,
        config.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(config.betweenHalf);

        DOTween.To(
        () => config.rightAlphas[i],
        z => config.rightAlphas[i] = z,
        255,
        config.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(config.betweenChar);
        StartCoroutine(Smooth(i + 1));
    }
    public void TicketText()
    {
        ticketText.text = $"{config.ticketAmmount}";
    }
    public void ExitButton()
    {
        _uiTraderMenu.SetActive(false);
    }
    public void TicketButton()
    {
        if (playerData.money >= 50)
        {
            config.ticketAmmount++;
            playerData.money -= 50;
            ticketText.text = $"{config.ticketAmmount}"; 
        }
        else
        {
            config.ticketAmmount -= 0;
            ticketText.text = $"{config.ticketAmmount}";            
        }
        
          
        
    }
    public void ExtraTask()
    {

    }


}
