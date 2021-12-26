using UnityEngine;
using UnityEngine.UI;

public class SkrejalUI : MonoBehaviour
{
    [SerializeField] private Image[] skrejalImages;
    [SerializeField] private Color findColor;

    private void Start()
    {
        if (PlayerData.Skrejal1)
            skrejalImages[0].color = findColor;
        if (PlayerData.Skrejal2)
            skrejalImages[1].color = findColor;
        if (PlayerData.Skrejal3)
            skrejalImages[2].color = findColor;
        if (PlayerData.Skrejal4)
            skrejalImages[3].color = findColor;
    }

    public void FindSkrejal(int skrejalNumber)
    {
        skrejalImages[skrejalNumber - 1].color = findColor;
    }
}
