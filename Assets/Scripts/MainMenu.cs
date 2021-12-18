using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Sprite arabKilledSprite;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Image arab;
    [SerializeField] private Text logoText;

    private void Awake()
    {
        PlayerData.LoadData();
    }

    private void Start()
    {
        if(PlayerData.ArabKilled)
        {
            arab.sprite = arabKilledSprite;
            mainCamera.backgroundColor = Color.black;
            logoText.color = Color.red;
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
}
