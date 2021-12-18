using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject arab, arabKilled, playDoh, porkchop;
    [SerializeField] private Text logoText;

    private void Awake()
    {
        PlayerData.LoadData();
    }

    private void Start()
    {
        if(PlayerData.EatPorkchop)
        {
            mainCamera.backgroundColor = Color.gray;
            playDoh.SetActive(false);
            porkchop.SetActive(true);
        }

        if(PlayerData.ArabKilled)
        {
            mainCamera.backgroundColor = Color.black;
            logoText.color = Color.red;
            arab.SetActive(false);
            arabKilled.SetActive(true);
        }
    }

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

    public void ArabFight()
    {
        SceneManager.LoadScene(ScenesName.RealFriend);
    }

    public void ResetData()
    {
        PlayerData.ResetData();
    }
}
