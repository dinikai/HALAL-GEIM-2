using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDialogFinish : MonoBehaviour
{
    private void Awake()
    {
        PlayerData.DialogFinished = true;
        PlayerData.SaveData();
    }
}
