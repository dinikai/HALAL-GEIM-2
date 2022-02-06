using UnityEngine;

public class AwakePosition : MonoBehaviour
{
    [SerializeField] private GameObject surfCollider, surfImage;
    public Vector2 afterSubway;
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
    }
}