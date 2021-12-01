using UnityEngine;
using UnityEngine.UI;

public class BArabText : MonoBehaviour
{
    private Text textObject;
    public string text, currentText = "";
    private int currentLetter = -1;

    void Start()
    {
        textObject = GetComponent<Text>();

        NextLetter();
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
        
    }
}
