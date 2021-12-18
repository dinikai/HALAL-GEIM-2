using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private GameObject porkPanel, skrejalPanel;
    [SerializeField] private GameObject skrejal1, skrejal2, skrejal3, skrejal4;
    public static int skrejalNumber;
    public static string SelectedItem { get; set; } = "";

    public void UseItem()
    {
        switch(SelectedItem)
        {
            case "pork":
                porkPanel.SetActive(true);
                PorkchopPanel.PorkPanelActive = true;
                break;
            case "skrejal":
                switch(skrejalNumber)
                {
                    case 1:
                        PlayerData.Skrejal1 = true;
                        break;
                    case 2:
                        PlayerData.Skrejal2 = true;
                        break;
                    case 3:
                        PlayerData.Skrejal3 = true;
                        break;
                    case 4:
                        PlayerData.Skrejal4 = true;
                        break;
                }
                skrejalPanel.SetActive(true);
                PlayerData.SaveData();
                break;
        }
    }

    public void HidePorkPanel()
    {
        porkPanel.SetActive(false);
    }

    public void EatPorkchop()
    {
        porkPanel.SetActive(true);

        PlayerData.EatPorkchop = true;
        PlayerPrefs.SetInt("epork", 1);
        PlayerPrefs.Save();
    }
}
