using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrejalPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public static bool SkrejalPanelActive = false;

    public void Close()
    {
        panel.SetActive(false);
    }
}