using UnityEngine;
using UnityEngine.UI;

public class HalalShop : MonoBehaviour
{
    [SerializeField] private Button useButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerData.Skate1 && PlayerData.Skate2 && PlayerData.Skate3)
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = UsableItem.HalalShop;
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
