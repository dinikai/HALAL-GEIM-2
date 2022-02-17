using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollider : MonoBehaviour
{
    [SerializeField] private GameObject questPanel;
    [SerializeField] private PlayerMove effenMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            questPanel.SetActive(true);
            effenMove.canMove = false;
        }
    }
}
