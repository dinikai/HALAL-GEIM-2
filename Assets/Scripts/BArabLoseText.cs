using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BArabLoseText : MonoBehaviour
{
    private Text textObject;
    public string text, currentText = "";
    private int currentLetter = -1;
    private AudioSource voice;

    void Start()
    {
        textObject = GetComponent<Text>();
        voice = GetComponent<AudioSource>();

        NextLetter();
    }

    public void NextLetter()
    {
        if (currentLetter < text.Length - 1)
        {
            currentLetter++;
            currentText += text[currentLetter];
            textObject.text = currentText;
            voice.Play();

            Invoke(nameof(NextLetter), text[currentLetter] != '.' ? 0.1f : 0.45f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(ScenesName.RealFriend);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(ScenesName.Menu);
    }
}
