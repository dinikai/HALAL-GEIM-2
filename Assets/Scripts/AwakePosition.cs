using UnityEngine;
using UnityEngine.UI;

public class AwakePosition : MonoBehaviour
{
    [SerializeField] private GameObject surfCollider, surfImage, allahCollider, barrier, allahImage, skate1, skate3;
    [SerializeField] private Slider effenSlider;
    [SerializeField] private AudioSource bgMusic;
    public Vector2 afterSubway, afterAllah;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerData.LoadData();

        if(PlayerData.SurfComplete)
        {
            Destroy(surfCollider);
            rb.position = afterSubway;

            surfImage.SetActive(true);
        }
        if(PlayerData.AllahKilled)
        {
            Destroy(allahCollider);
            Destroy(barrier);
            rb.position = afterAllah;

            allahImage.SetActive(true);
        }
        if (PlayerData.Skate1)
            Destroy(skate1);
        if (PlayerData.Skate3)
            Destroy(skate3);

        if(PlayerData.EatPorkchop)
        {
            bgMusic.pitch = 0.7f;
        }
    }

    private void FixedUpdate()
    {
        effenSlider.value = PlayerData.HP;
    }
}
