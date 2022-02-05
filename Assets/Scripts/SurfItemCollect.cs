using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SurfItemCollect : MonoBehaviour
{
    [SerializeField] private GameObject endCollider;
    [SerializeField] private AudioSource itemCollectSound, itemCollectEchoSound, mustacheSound;
    [SerializeField] private Animator musicFade;
    [SerializeField] private Text coinsText;
    [SerializeField] private PostProcessProfile normalProfile, mustacheProfile;
    [SerializeField] private PostProcessVolume mainVolume;
    public int skatesNumber = 0, coinsNumber = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SurfSkateboard"))
        {
            SurfSkateboard skateboard = collision.gameObject.GetComponent<SurfSkateboard>();
            int skateNumber = skateboard.skateNumber;

            switch (skateNumber)
            {
                case 1:
                    PlayerData.Skate1 = true;
                    break;
                case 2:
                    PlayerData.Skate2 = true;
                    break;
                case 3:
                    PlayerData.Skate3 = true;
                    break;
            }

            PlayerData.SaveData();

            itemCollectEchoSound.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SurfCoin"))
        {
            coinsNumber++;
            if (coinsNumber == 25)
            {
                endCollider.SetActive(true);
                PlayerData.SurfComplete = true;
                PlayerData.SaveData();
            }

            coinsText.text = coinsNumber + "/25";

            itemCollectSound.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SurfMustache"))
        {
            StartCoroutine(MustacheMode());

            mustacheSound.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SurfRightCollider"))
        {
            SlideCollider slide = collision.gameObject.GetComponent<SlideCollider>();
            slide.slideBox.Play("SlideRight", 0, 0);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SurfLeftCollider"))
        {
            SlideCollider slide = collision.gameObject.GetComponent<SlideCollider>();
            slide.slideBox.Play("SlideLeft", 0, 0);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SurfEndLevel"))
        {
            SurfPlayerMove move = GetComponent<SurfPlayerMove>();

            move.IsAlive = false;
            move.detector.SwipeEvent -= move.SwipeHandler;

            PlayerData.SurfComplete = true;
            PlayerData.SaveData();

            musicFade.Play("MusicFade");

            StartCoroutine(LevelEnd());
        }
    }

    IEnumerator MustacheMode()
    {
        mainVolume.profile = mustacheProfile;
        
        yield return new WaitForSeconds(3.5f);

        mainVolume.profile = normalProfile;
    }

    IEnumerator LevelEnd()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(ScenesName.Game1);
    }
}
