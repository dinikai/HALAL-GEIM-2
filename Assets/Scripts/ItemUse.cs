using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private GameObject porkPanel, skrejalPanel, basementBarrier, speedPanel, speedUI;
    [SerializeField] private AudioSource liftSound, itemCollectSound, barrierBreakSound;
    [SerializeField] private SkrejalUI skrejalUIController;
    public static int skrejalNumber;
    public static Vector2 liftVector;
    public static GameObject useItem;
    public static UsableItem SelectedItem { get; set; }

    private void Start()
    {
        if(PlayerData.SpeedImprove)
        {
            GetComponent<PlayerMove>().speed += 0.05f;
        }
    }

    public void UseItem()
    {
        switch(SelectedItem)
        {
            case UsableItem.Pork:
                porkPanel.SetActive(true);
                PorkchopPanel.PorkPanelActive = true;
                itemCollectSound.Play();
                break;
            case UsableItem.Skrejal:
                switch(skrejalNumber)
                {
                    case 1:
                        PlayerData.Skrejal1 = true;
                        break;
                    case 2:
                        PlayerData.Skrejal2 = true;
                        break;
                    case 3:
                        PlayerData.Skrejal3 = true;
                        break;
                    case 4:
                        PlayerData.Skrejal4 = true;
                        break;
                }
                skrejalPanel.SetActive(true);
                Destroy(useItem);
                skrejalUIController.FindSkrejal(skrejalNumber);
                itemCollectSound.Play();

                if(PlayerData.Skrejal1 && PlayerData.Skrejal2 && PlayerData.Skrejal3 && PlayerData.Skrejal4)
                {
                    Destroy(basementBarrier);
                    PlayerData.BreakedBarrier = true;
                    barrierBreakSound.Play();
                }

                PlayerData.SaveData();
                break;
            case UsableItem.Lift:
                GetComponent<Rigidbody2D>().position = liftVector;
                liftSound.Play();
                break;
            case UsableItem.SpeedUpImprove:
                speedPanel.SetActive(true);
                speedUI.SetActive(true);

                PlayerData.SpeedImprove = true;
                PlayerData.SaveData();
                Destroy(useItem);

                GetComponent<PlayerMove>().speed += 0.05f;
                break;
        }
    }

    public void HidePorkPanel()
    {
        porkPanel.SetActive(false);
    }

    public void EatPorkchop()
    {
        porkPanel.SetActive(true);

        PlayerData.EatPorkchop = true;
        PlayerPrefs.SetInt("epork", 1);
        PlayerPrefs.Save();
    }
}

public enum UsableItem
{
    Pork,
    Skrejal,
    Lift,
    SpeedUpImprove
}