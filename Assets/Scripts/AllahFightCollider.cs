using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllahFightCollider : MonoBehaviour
{
    [SerializeField] private Animator musicAnimator, allahAnimator, fadeAnimator;
    [SerializeField] private AudioSource fightStartMusic;
    public bool Collided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collided = true;
            musicAnimator.Play("MusicFade", 0, 0);

            StartCoroutine(StartFight());
        }
    }

    private IEnumerator StartFight()
    {
        fightStartMusic.Play();
        yield return new WaitForSeconds(fightStartMusic.clip.length + 1);
        allahAnimator.Play("AllahSteps", 0, 0);
        fadeAnimator.gameObject.SetActive(true);
        fadeAnimator.Play("FadePanel1", 0, 0);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(ScenesName.Allah);
    }
}
