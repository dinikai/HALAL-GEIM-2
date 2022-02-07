using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HotZone : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private AudioSource damageSound;
    public bool InZone = false;

    private void Start()
    {
        StartCoroutine(HealthDown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InZone = false;
    }

    private IEnumerator HealthDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.5f);

            if (InZone)
            {
                PlayerData.HP -= 7;
                healthSlider.value = PlayerData.HP;
                damageSound.Play();
            }
        }
    }
}
