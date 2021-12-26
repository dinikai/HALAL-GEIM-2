using UnityEngine;
using UnityEngine.UI;

public class Lift : MonoBehaviour
{
    [SerializeField] private Button useButton;
    public Vector2 vector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            useButton.interactable = true;
            ItemUse.SelectedItem = UsableItem.Lift;
            ItemUse.liftVector = vector;
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
