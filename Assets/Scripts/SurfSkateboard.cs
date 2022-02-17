using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfSkateboard : MonoBehaviour
{
    public int skateNumber;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerData.Skate2 = true;
        PlayerData.SaveData();

        Destroy(gameObject);
    }
}
