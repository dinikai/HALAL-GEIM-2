using UnityEngine;
using UnityEngine.UI;

public class BArabText : MonoBehaviour
{
    private AudioSource doomSource;
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private GameObject buttonBlock, buttonAttack, bArab;
    [SerializeField] private string[] thinks;
    private Text textObject;
    public string text, currentText = "";
    private int currentLetter = -1;

    void Start()
    {
        textObject = GetComponent<Text>();
        doomSource = GetComponent<AudioSource>();

        NextLetter();
    }

    private void Update()
    {
    }

    public void NextLetter()
    {
        if (currentLetter < text.Length - 1)
        {
            currentLetter++;
            currentText += text[currentLetter];
            textObject.text = currentText;

            Invoke(nameof(NextLetter), text[currentLetter] != '.' ? 0.1f : 0.45f);
        }
        else
        {
            Invoke(nameof(StartBegin), 2);
        }
    }

    private void StartBegin()
    {
        fadeAnimator.Play("FadePanel1", 0, 0);
        doomSource.Play();
        buttonBlock.SetActive(true);
        buttonAttack.SetActive(true);
        bArab.SetActive(true);

        textObject.text = "Your death appeared. You feel its your end.";
    }
}
