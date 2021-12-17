using System;
using System.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int DialogNumber { get; set; }
    public static int HP { get; set; } = 100;
    public static bool EatPorkchop { get; set; } = false;
    public static bool ArabKilled { get; set; } = false;

    private void Awake()
    {
        LoadData();
    }

    public static void LoadData()
    {
        DialogNumber = PlayerPrefs.GetInt("dnum");
        HP = PlayerPrefs.GetInt("hp");
        EatPorkchop = Convert.ToBoolean(PlayerPrefs.GetInt("epork"));
        ArabKilled = Convert.ToBoolean(PlayerPrefs.GetInt("arabkill"));
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("dnum", DialogNumber);
        PlayerPrefs.SetInt("hp", HP);
        PlayerPrefs.SetInt("epork", Convert.ToInt32(EatPorkchop));
        PlayerPrefs.SetInt("arabkill", Convert.ToInt32(ArabKilled));

        PlayerPrefs.Save();
    }
}

public struct ScenesName
{
    public static string Menu { get; } = "Menu";
    public static string Intro { get; } = "Intro";
    public static string Begin { get; } = "Begin";
    public static string Title { get; } = "Title1";
    public static string Game1 { get; } = "HalalGeim2";
    public static string RealFriend { get; } = "RealFriendFight";
    public static string RealLose { get; } = "BArabLose";
    public static string BadEnd { get; } = "BadEnd";
}