using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllahFightCollider : MonoBehaviour
{
    [SerializeField] private Animator musicAnimator;
    public bool Collided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collided = true;
            musicAnimator.Play("MusicFade", 0, 0);
        }
    }
}
