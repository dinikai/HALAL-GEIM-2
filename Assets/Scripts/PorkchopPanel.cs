using UnityEngine;
using UnityEngine.UI;

public class PorkchopPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Slider healthBar;
    public static bool PorkPanelActive = false;

    public void EatPorkchop()
    {
        PlayerData.EatPorkchop = true;
        PlayerData.HP += 50;
        PlayerData.HP = Mathf.Clamp(PlayerData.HP, 0, 100);
        PlayerData.SaveData();
        healthBar.value = PlayerData.HP;

        Destroy(ItemUse.useItem);

        panel.SetActive(false);
        PorkPanelActive = false;
    }

    public void DoNot()
    {
        panel.SetActive(false);
        PorkPanelActive = false;
    }
}
