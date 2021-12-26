using UnityEngine;
using UnityEngine.UI;

public class SpeedImprovePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel, improve, improveUI;
    public static bool ImprovePanelActive = false;

    private void Start()
    {
        if (PlayerData.SpeedImprove)
        {
            Destroy(improve);
            improveUI.SetActive(true);
        }
    }

    public void Close()
    {
        panel.SetActive(false);
        ImprovePanelActive = false;
    }
}
