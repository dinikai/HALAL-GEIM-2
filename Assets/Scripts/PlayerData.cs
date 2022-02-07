using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int DialogNumber { get; set; } = 0;
    public static int HP { get; set; } = 100;
    public static bool EatPorkchop { get; set; } = false;
    public static bool ArabKilled { get; set; } = false;
    public static bool Skrejal1 { get; set; } = false;
    public static bool Skrejal2 { get; set; } = false;
    public static bool Skrejal3 { get; set; } = false;
    public static bool Skrejal4 { get; set; } = false;
    public static bool DialogFinished { get; set; } = false;
    public static bool SpeedImprove { get; set; } = false;
    public static bool BreakedBarrier { get; set; } = false;
    public static bool Skate1 { get; set; } = false;
    public static bool Skate2 { get; set; } = false;
    public static bool Skate3 { get; set; } = false;
    public static bool SurfComplete { get; set; } = false;
    public static bool AllahKilled { get; set; } = false;

    public static void LoadData()
    {
        if (PlayerPrefs.HasKey("dnum"))
            DialogNumber = PlayerPrefs.GetInt("dnum");
        if (PlayerPrefs.HasKey("hp"))
            HP = PlayerPrefs.GetInt("hp");
        if (PlayerPrefs.HasKey("eatpork"))
            EatPorkchop = Convert.ToBoolean(PlayerPrefs.GetInt("eatpork"));
        if (PlayerPrefs.HasKey("arabkill"))
            ArabKilled = Convert.ToBoolean(PlayerPrefs.GetInt("arabkill"));

        if (PlayerPrefs.HasKey("skr1"))
            Skrejal1 = Convert.ToBoolean(PlayerPrefs.GetInt("skr1"));
        if (PlayerPrefs.HasKey("skr2"))
            Skrejal2 = Convert.ToBoolean(PlayerPrefs.GetInt("skr2"));
        if (PlayerPrefs.HasKey("skr3"))
            Skrejal3 = Convert.ToBoolean(PlayerPrefs.GetInt("skr3"));
        if (PlayerPrefs.HasKey("skr4"))
            Skrejal4 = Convert.ToBoolean(PlayerPrefs.GetInt("skr4"));

        if (PlayerPrefs.HasKey("dfinish"))
            DialogFinished = Convert.ToBoolean(PlayerPrefs.GetInt("dfinish"));
        if (PlayerPrefs.HasKey("impspeed"))
            SpeedImprove = Convert.ToBoolean(PlayerPrefs.GetInt("impspeed"));
        if (PlayerPrefs.HasKey("barrier"))
            BreakedBarrier = Convert.ToBoolean(PlayerPrefs.GetInt("barrier"));

        if (PlayerPrefs.HasKey("skate1"))
            Skate1 = Convert.ToBoolean(PlayerPrefs.GetInt("skate1"));
        if (PlayerPrefs.HasKey("skate2"))
            Skate2 = Convert.ToBoolean(PlayerPrefs.GetInt("skate2"));
        if (PlayerPrefs.HasKey("skate3"))
            Skate3 = Convert.ToBoolean(PlayerPrefs.GetInt("skate3"));

        if (PlayerPrefs.HasKey("surfcomp"))
            SurfComplete = Convert.ToBoolean(PlayerPrefs.GetInt("surfcomp"));
        if (PlayerPrefs.HasKey("allah"))
            AllahKilled = Convert.ToBoolean(PlayerPrefs.GetInt("allah"));
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("dnum", DialogNumber);
        PlayerPrefs.SetInt("hp", HP);
        PlayerPrefs.SetInt("eatpork", Convert.ToInt32(EatPorkchop));
        PlayerPrefs.SetInt("arabkill", Convert.ToInt32(ArabKilled));

        PlayerPrefs.SetInt("skr1", Convert.ToInt32(Skrejal1));
        PlayerPrefs.SetInt("skr2", Convert.ToInt32(Skrejal2));
        PlayerPrefs.SetInt("skr3", Convert.ToInt32(Skrejal3));
        PlayerPrefs.SetInt("skr4", Convert.ToInt32(Skrejal4));

        PlayerPrefs.SetInt("dfinish", Convert.ToInt32(DialogFinished));
        PlayerPrefs.SetInt("impspeed", Convert.ToInt32(SpeedImprove));
        PlayerPrefs.SetInt("barrier", Convert.ToInt32(BreakedBarrier));

        PlayerPrefs.SetInt("skate1", Convert.ToInt32(Skate1));
        PlayerPrefs.SetInt("skate2", Convert.ToInt32(Skate2));
        PlayerPrefs.SetInt("skate3", Convert.ToInt32(Skate3));

        PlayerPrefs.SetInt("surfcomp", Convert.ToInt32(SurfComplete));
        PlayerPrefs.SetInt("allah", Convert.ToInt32(AllahKilled));

        PlayerPrefs.Save();
    }

    public static void ResetData()
    {
        DialogNumber = 0;
        HP = 100;
        EatPorkchop = false;
        ArabKilled = false;
        BArabFight.ArabHP = 600;
        Skrejal1 = false;
        Skrejal2 = false;
        Skrejal3 = false;
        Skrejal4 = false;
        DialogFinished = false;
        SpeedImprove = false;
        BreakedBarrier = false;
        Skate1 = false;
        Skate2 = false;
        Skate3 = false;
        SurfComplete = false;
        AllahKilled = false;

        PlayerPrefs.SetInt("dnum", DialogNumber);
        PlayerPrefs.SetInt("hp", HP);
        PlayerPrefs.SetInt("eatpork", Convert.ToInt32(EatPorkchop));
        PlayerPrefs.SetInt("arabkill", Convert.ToInt32(ArabKilled));

        PlayerPrefs.SetInt("skr1", Convert.ToInt32(Skrejal1));
        PlayerPrefs.SetInt("skr2", Convert.ToInt32(Skrejal2));
        PlayerPrefs.SetInt("skr3", Convert.ToInt32(Skrejal3));
        PlayerPrefs.SetInt("skr4", Convert.ToInt32(Skrejal4));

        PlayerPrefs.SetInt("dfinish", Convert.ToInt32(DialogFinished));
        PlayerPrefs.SetInt("impspeed", Convert.ToInt32(SpeedImprove));
        PlayerPrefs.SetInt("barrier", Convert.ToInt32(BreakedBarrier));

        PlayerPrefs.SetInt("skate1", Convert.ToInt32(Skate1));
        PlayerPrefs.SetInt("skate2", Convert.ToInt32(Skate2));
        PlayerPrefs.SetInt("skate3", Convert.ToInt32(Skate3));

        PlayerPrefs.SetInt("surfcomp", Convert.ToInt32(SurfComplete));
        PlayerPrefs.SetInt("allah", Convert.ToInt32(AllahKilled));

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
    public static string Allah { get; } = "AllahFight";
    public static string RealLose { get; } = "BArabLose";
    public static string AllahLose { get; } = "AllahLose";
    public static string BadEnd { get; } = "BadEnd";
    public static string Disclaimer { get; } = "Disclaimer";
    public static string Surf { get; } = "SubwaySurf";
}