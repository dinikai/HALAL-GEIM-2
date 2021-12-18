using UnityEngine;
using UnityEngine.UI;

public class Porkchop : MonoBehaviour
{
    [SerializeField] private Button useButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = "pork";
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
