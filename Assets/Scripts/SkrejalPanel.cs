using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrejalPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel, skrejal1, skrejal2, skrejal3, skrejal4;
    public static bool SkrejalPanelActive = false;

    private void Start()
    {
        if (PlayerData.Skrejal1)
            Destroy(skrejal1);
        if (PlayerData.Skrejal2)
            Destroy(skrejal2);
        if (PlayerData.Skrejal3)
            Destroy(skrejal3);
        if (PlayerData.Skrejal4)
            Destroy(skrejal4);
    }

    public void Close()
    {
        panel.SetActive(false);
        SkrejalPanelActive = false;
    }
}