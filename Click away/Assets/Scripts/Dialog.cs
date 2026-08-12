using System.Collections;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    [SerializeField] private dialogelements[] dialog;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private TextMeshProUGUI CharacterName;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private AudioSource audioSource;
    private int index;

    void Start()
    {
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
        characterAnimator.runtimeAnimatorController = dialog[index].characterGif;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialog[index].talk.ToCharArray())
        {
            textComponent.text += c;
            audioSource.pitch = Random.Range(0.2f, 1.8f);
            audioSource.PlayOneShot(dialog[index].characterVoice);
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
            characterAnimator.runtimeAnimatorController = dialog[index].characterGif;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
