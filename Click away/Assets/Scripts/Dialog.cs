using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private dialogelements[] dialog;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private TextMeshProUGUI CharacterName;
    [SerializeField] private RawImage characterImage;
    private int index;
    private Texture profile;

    void Start()
    {
        profile = characterImage.texture;
        textComponent.text = string.Empty;
        StartDialog();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialog[index].talk)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialog[index].talk;
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
        CharacterName.text = dialog[index].characterName;
        characterImage.texture = dialog[index].characterImage.texture;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialog[index].talk.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialog.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            CharacterName.text = dialog[index].characterName;
            characterImage.texture = dialog[index].characterImage.texture;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
