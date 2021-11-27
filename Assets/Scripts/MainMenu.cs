using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(ScenesName.Intro);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pig()
    {
        GetComponent<AudioSource>().Play();
    }
}
