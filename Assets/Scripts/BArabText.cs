using System;
using UnityEngine;
using UnityEngine.UI;

public class BArabText : MonoBehaviour
{
    public AudioSource doomSource;
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private GameObject[] enablableItems;
    [SerializeField] private GameObject bArab;
    [SerializeField] private string[] thinks;
    [SerializeField] private BArabFight fight;
    public float textSpeed, dotDelay;
    private AudioSource voice;
    private Text textObject;
    public string text, currentText = "";
    private int currentLetter = -1;
    public bool hasVoice = true;
    public delegate void AfterMethod();
    private AfterMethod doAfter;

    void Start()
    {
        textObject = GetComponent<Text>();
        voice = GetComponent<AudioSource>();

        text = thinks[0];

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

            if(hasVoice)
                voice.Play();

            Invoke(nameof(NextLetter), text[currentLetter] != '.' ? textSpeed : dotDelay);
        }
        else
        {
            if(text == thinks[0])
            {
                Invoke(nameof(StartBegin), 2);
                fight.StartCoroutine(fight.BArabMusicSync());

                textSpeed = 0.04f;
                hasVoice = false;
            }
        }
    }

    public void PrintToText(string newText)
    {
        text = newText;
        currentText = "";
        currentLetter = -1;

        NextLetter();
    }

    public void PrintToText(string newText, AfterMethod after)
    {
        text = newText;
        currentText = "";
        currentLetter = -1;

        NextLetter();

        doAfter = after;
    }

    private void StartBegin()
    {
        fadeAnimator.Play("FadePanel1", 0, 0);
        doomSource.Play();

        SetEnable(true);

        bArab.SetActive(true);
        bArab.GetComponent<Animator>().Play("BArabIdle");
        BArabFight.Dogovoril = true;

        PrintToText("Your death appeared. You feel its end of your journey.");
    }

    private void E()
    {
        fight.PorkBombRain();
    }

    public void SetEnable(bool state)
    {
        foreach (GameObject item in enablableItems)
        {
            item.SetActive(state);
        }
    }
}
