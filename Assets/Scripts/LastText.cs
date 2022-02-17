using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastText : MonoBehaviour
{
    [SerializeField] private string[] thinks;
    [SerializeField] private PlayerMove move;
    [SerializeField] private Text textObject;
    [SerializeField] private SpriteRenderer arabSprite;
    [SerializeField] private Sprite arab;
    public float textSpeed, dotDelay;
    [SerializeField] private AudioSource voice, bgMusic, uron;
    public string text, currentText = "";
    private int currentLetter = -1;
    public bool hasVoice = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textObject.gameObject.SetActive(true);
        move.canMove = false;
        NextLetter();
    }

    public void NextLetter()
    {
        if (currentLetter < text.Length - 1)
        {
            currentLetter++;
            currentText += text[currentLetter];
            textObject.text = currentText;

            if (hasVoice)
                voice.Play();

            Invoke(nameof(NextLetter), text[currentLetter] != '.' ? textSpeed : dotDelay);
        }
        else
        {
            StartCoroutine(AfterText());
        }
    }

    private IEnumerator AfterText()
    {
        arabSprite.sprite = arab;
        bgMusic.Stop();
        uron.Play();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(ScenesName.RealFriend);
    }
}
