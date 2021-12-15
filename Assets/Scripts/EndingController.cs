using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public static bool PorkchopEaten = false;

    private void Start()
    {
        bool hasPorkchopkey = PlayerPrefs.HasKey("PorkchopEaten");

        if(hasPorkchopkey)
        {
            if(PlayerPrefs.GetInt("PorkchopEaten") == 1)
            {
                PorkchopEaten = true;
            }
            else
            {
                PorkchopEaten = false;
            }
        }
    }
}
