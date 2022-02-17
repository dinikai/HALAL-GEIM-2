using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllahLose : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(ScenesName.Allah);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(ScenesName.Menu);
    }
}
