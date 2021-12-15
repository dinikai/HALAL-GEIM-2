using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed);
        speed *= 1.05f;

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Animator>().Play("EffewbergHurt", 0, 0);
            PlayerData.HP -= 2;
        }
    }
}
