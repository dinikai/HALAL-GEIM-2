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
            ItemUse.SelectedItem = UsableItem.Pork;
            ItemUse.useItem = gameObject;
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
