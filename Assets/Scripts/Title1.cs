using UnityEngine;
using UnityEngine.SceneManagement;

public class Title1 : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(ChangeScene), 3);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(ScenesName.Game1);
    }
}
