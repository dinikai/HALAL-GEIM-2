using UnityEngine;
using UnityEngine.UI;

public class Skrejal : MonoBehaviour
{
    [SerializeField] private Button useButton;
    public int skrejalNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = "skrejal";
            ItemUse.skrejalNumber = skrejalNumber;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = false;
        }
    }
}
