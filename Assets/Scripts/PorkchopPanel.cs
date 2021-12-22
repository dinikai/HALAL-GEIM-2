using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorkchopPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public static bool PorkPanelActive = false;

    public void EatPorkchop()
    {
        PlayerData.EatPorkchop = true;
        PlayerData.SaveData();

        panel.SetActive(false);
        PorkPanelActive = false;
    }

    public void DoNot()
    {
        panel.SetActive(false);
        PorkPanelActive = false;
    }
}
