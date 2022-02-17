using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMusicCollider : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioClip normalMusic, finalMusic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bgMusic.clip = finalMusic;
            bgMusic.Play();
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bgMusic.clip = normalMusic;
            bgMusic.Play();
        }
    }*/
}
