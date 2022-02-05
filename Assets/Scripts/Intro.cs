using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private string scene;
    private Text textObject;
    private AudioSource pig;
    public string text, currentText = "";
    private int currentLetter = -1;

    void Start()
    {
        textObject = GetComponent<Text>();
        pig = GetComponent<AudioSource>();

        NextLetter();
    }

    public void NextLetter()
    {
        if(currentLetter < text.Length - 1)
        {
            currentLetter++;
            currentText += text[currentLetter];
            textObject.text = currentText;

            pig.Play();

            Invoke(nameof(NextLetter), text[currentLetter] != '.' ? 0.1f : 0.45f);
        } else
        {
            Invoke(nameof(StartBegin), 2);
        }
    }

    private void StartBegin()
    {
        SceneManager.LoadScene(scene);
    }
}
