using UnityEngine;

public class AwakePosition : MonoBehaviour
{
    [SerializeField] private GameObject surfCollider, surfImage, allahCollider, barrier, allahImage;
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
    }
}
