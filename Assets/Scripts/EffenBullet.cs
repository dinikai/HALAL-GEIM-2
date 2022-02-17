using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffenBullet : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(1, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            BArabFight.ArabHP -= 3;
        }
        if (other.CompareTag("Allah"))
        {
            AllahFight.AllahHP -= 3;
        }
    }
}
