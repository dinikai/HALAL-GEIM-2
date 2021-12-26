using UnityEngine;
using UnityEngine.UI;

public class SpeedImprove : MonoBehaviour
{
    [SerializeField] private Button useButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = UsableItem.SpeedUpImprove;
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
