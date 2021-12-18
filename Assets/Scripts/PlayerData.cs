using System;
using System.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int DialogNumber { get; set; }
    public static int HP { get; set; } = 100;
    public static bool EatPorkchop { get; set; } = false;
    public static bool ArabKilled { get; set; } = false;

    public static void LoadData()
    {
        if(PlayerPrefs.HasKey("dnum"))
            DialogNumber = PlayerPrefs.GetInt("dnum");
        if(PlayerPrefs.HasKey("hp"))
            HP = PlayerPrefs.GetInt("hp");
        if(PlayerPrefs.HasKey("eatpork"))
            EatPorkchop = Convert.ToBoolean(PlayerPrefs.GetInt("eatpork"));
        if(PlayerPrefs.HasKey("arabkill"))
            ArabKilled = Convert.ToBoolean(PlayerPrefs.GetInt("arabkill"));
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("dnum", DialogNumber);
        PlayerPrefs.SetInt("hp", HP);
        PlayerPrefs.SetInt("eatpork", Convert.ToInt32(EatPorkchop));
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