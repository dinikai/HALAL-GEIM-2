using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorkBomb : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Animator>().Play("EffewbergHurt", 0, 0);
            PlayerData.HP -= 1;
        }
    }
}
