using System.Collections;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Sdox), 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().Play("EffewbergHurt", 0, 0);
            if (PlayerData.EatPorkchop)
                PlayerData.HP -= 10;
            else
                PlayerData.HP -= 3;
            Destroy(gameObject);
        }
    }

    private void Sdox()
    {
        Destroy(gameObject);
    }
}
