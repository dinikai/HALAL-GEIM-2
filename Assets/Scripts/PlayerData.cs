using System;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int DialogNumber { get; set; }

    public static void LoadData()
    {
        StreamReader stream = new StreamReader(Application.persistentDataPath + "/save.4rp");
        string[] data = stream.ReadToEnd().Split();

        DialogNumber = Convert.ToInt32(data[0]);
    }

    public static void SaveData()
    {
        StreamWriter stream = new StreamWriter(Application.persistentDataPath + "/save.4rp");

        stream.Write(DialogNumber);
    }
}

public struct ScenesName
{
    public static string Menu { get; } = "Menu";
    public static string Intro { get; } = "Intro";
    public static string Begin { get; } = "Begin";
    public static string Title { get; } = "Title1";
    public static string Game1 { get; } = "HalalGeim2";
}