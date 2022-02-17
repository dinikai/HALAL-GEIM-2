using UnityEngine;
using UnityEngine.UI;

public class Skateboard : MonoBehaviour
{
    [SerializeField] private Button useButton;
    public int skateNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = UsableItem.Skate;
            ItemUse.skateNumber = skateNumber;
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
