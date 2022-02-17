using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] private GameObject q1, q2, q3, q4, q5, qa1, qa2, qn1, qn2, qPanel, qCollider;
    [SerializeField] private AudioSource correctSound, noSound;
    [SerializeField] private PlayerMove effenMove;
    public int questionNum = 1;

    public void YesButton()
    {
        switch (questionNum)
        {
            case 1:
                noSound.Play();
                PlayerData.HP -= 10;
                qn1.SetActive(true);
                q1.SetActive(false);
                q2.SetActive(true);
                questionNum++;
                break;
            case 2:
                noSound.Play();
                PlayerData.HP -= 10;
                qn2.SetActive(true);
                q2.SetActive(false);
                q3.SetActive(true);
                questionNum++;
                break;
            case 3:
                qa2.SetActive(true);
                correctSound.Play();
                q3.SetActive(false);
                q4.SetActive(true);
                questionNum++;
                break;
            case 4:
                noSound.Play();
                PlayerData.HP -= 10;
                qn2.SetActive(true);
                q4.SetActive(false);
                q5.SetActive(true);
                questionNum++;
                break;
            case 5:
                qa2.SetActive(true);
                correctSound.Play();
                qPanel.SetActive(false);
                qCollider.SetActive(false);
                effenMove.canMove = true;
                break;
        }
    }

    public void NoButton()
    {
        switch (questionNum)
        {
            case 1:
                qa1.SetActive(true);
                correctSound.Play();
                q1.SetActive(false);
                q2.SetActive(true);
                questionNum++;
                break;
            case 2:
                qa2.SetActive(true);
                correctSound.Play();
                q2.SetActive(false);
                q3.SetActive(true);
                questionNum++;
                break;
            case 3:
                noSound.Play();
                PlayerData.HP -= 10;
                qn2.SetActive(true);
                q3.SetActive(false);
                q4.SetActive(true);
                questionNum++;
                break;
            case 4:
                correctSound.Play();
                qa2.SetActive(true);
                q4.SetActive(false);
                q5.SetActive(true);
                questionNum++;
                break;
            case 5:
                noSound.Play();
                PlayerData.HP -= 10;
                q5.SetActive(false);
                qn2.SetActive(true);
                qPanel.SetActive(false);
                qCollider.SetActive(false);
                effenMove.canMove = true;
                break;
        }
    }

    public void OkButton()
    {
        qa1.SetActive(false);
        qa2.SetActive(false);
        qn1.SetActive(false);
        qn2.SetActive(false);
    }
}
