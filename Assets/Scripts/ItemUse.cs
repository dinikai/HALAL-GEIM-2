using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private GameObject porkPanel;
    public static string SelectedItem { get; set; } = "";

    public void UseItem()
    {
        if(SelectedItem == "pork")
        {
            porkPanel.SetActive(true);
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
