using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    [SerializeField] private Text dialogPerson, dialogText;
    [SerializeField] private Image panel;
    [SerializeField] private GameObject friend, dialogBorder, realFriend;
    [SerializeField] private Sprite realFriendSprite, realFriendSpriteWhat, realFriendSpriteFair, realFriendSpriteSmile, realFriendSpriteBad;
    [SerializeField] private Sprite realFriendSpritePork, realFriendSpriteBurger, realFriendSpriteDemon;
    [SerializeField] private float lettersSpeed = 0.02f;
    private int lettersAdded = 0;
    private string currentString = "";
    private bool lettersEnabled = false;
    public static List<string[]> replicas = new List<string[]>();

    private void Start()
    {
        StreamReader stream = new StreamReader(Application.dataPath + "/PlayerData/replicas.4rp");
        string replicasString = stream.ReadToEnd();

        string[] replicasLines = replicasString.Split('\n');
        for (int i = 0; i < replicasLines.Length; i++)
        {
            replicas.Add(replicasLines[i].Split('>'));
        }

        string personName = PersonIdToName(Convert.ToInt32(replicas[PlayerData.DialogNumber][0]));
        dialogPerson.text = personName;

        dialogText.text = replicas[PlayerData.DialogNumber][1];
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && replicas.Count - 1 > PlayerData.DialogNumber)
        {
            NextDialog();

            string personName = PersonIdToName(Convert.ToInt32(replicas[PlayerData.DialogNumber][0]));
            dialogPerson.text = personName;

            string nextLocation = replicas[PlayerData.DialogNumber][2];
            nextLocation = nextLocation.Trim();

            if (nextLocation != "0")
            {
                GameObject[] locations = GameObject.FindGameObjectsWithTag("Location");

                for (int i = 0; i < locations.Length; i++)
                {
                    if (locations[i].name != nextLocation)
                        SetActiveChild(locations[i], false);
                    else
                        SetActiveChild(GameObject.Find(nextLocation), true);
                }
            }

            Color col = new Color(1, 1, 1, 0);

            string act = replicas[PlayerData.DialogNumber][3];
            act = act.Trim();

            string[] acts = act.Split(' ');

            for (int i = 0; i < acts.Length; i++)
            {
                switch(acts[i])
                {
                    case "frShow":
                        realFriend.SetActive(true);
                        break;
                    case "frHide":
                        realFriend.SetActive(false);
                        break;
                    case "brHide":
                        dialogBorder.SetActive(false);
                        dialogPerson.gameObject.SetActive(false);
                        dialogText.gameObject.SetActive(false);
                        break;
                    case "brShow":
                        dialogBorder.SetActive(true);
                        dialogPerson.gameObject.SetActive(true);
                        dialogText.gameObject.SetActive(true);
                        break;
                    case "frWhat":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteWhat;
                        break;
                    case "frNorm":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSprite;
                        break;
                    case "frFair":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteFair;
                        break;
                    case "frSmile":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteSmile;
                        break;
                    case "frBad":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteBad;
                        break;
                    case "frBurger":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteBurger;
                        break;
                    case "frPork":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpritePork;
                        break;
                    case "frDemon":
                        realFriend.GetComponent<SpriteRenderer>().sprite = realFriendSpriteDemon;
                        break;
                    case "colRed":
                        dialogText.color = Color.red;
                        break;
                    case "colBlue":
                        dialogText.color = Color.blue;
                        break;
                    case "colNorm":
                        dialogText.color = Color.white;
                        break;
                    case "txtSlow":
                        lettersSpeed = 0.15f;
                        break;
                    case "txtVslow":
                        lettersSpeed = 0.5f;
                        break;
                    case "txtNorm":
                        lettersSpeed = 0.02f;
                        break;
                    case "panDark":
                        col.a = 0.5f;
                        panel.color = col;
                        break;
                    case "panLdark":
                        col.a = 0.25f;
                        panel.color = col;
                        break;
                    case "panVdark":
                        col.a = 0.8f;
                        panel.color = col;
                        break;
                    case "panDis":
                        col.a = 0;
                        panel.color = col;
                        break;
                    case "halalGeim2":
                        SceneManager.LoadScene(ScenesName.Title);
                        break;
                }
            }
        }
    }

    public void NextDialog()
    {
        PlayerData.DialogNumber++;

        if(PlayerData.DialogNumber % 10 == 0)
            PlayerData.SaveData();

        lettersAdded = 0;
        currentString = "";
        lettersEnabled = true;

        AddLetter();
    }

    public static string PersonIdToName(int id)
    {
        StreamReader stream = new StreamReader(Application.dataPath + "/PlayerData/persons.4rp");
        string personsString = stream.ReadToEnd();

        string[] personsLines = personsString.Split('\n');

        return personsLines[id];
    }

    private void AddLetter()
    {
        if(replicas[PlayerData.DialogNumber][1].Length > lettersAdded && lettersEnabled)
        {
            currentString += replicas[PlayerData.DialogNumber][1][lettersAdded];
            dialogText.text = currentString;

            lettersAdded++;

            Invoke(nameof(AddLetter), lettersSpeed);
        } else
        {
            lettersAdded = 0;
            currentString = "";
            lettersEnabled = false;
        }
    }

    private void SetActiveChild(GameObject setObject, bool state)
    {
        int objectCount = setObject.transform.childCount;

        for(int i = 0; i < objectCount; i++)
        {
            if(!setObject.transform.GetChild(i).gameObject.CompareTag("NoEnable"))
                setObject.transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}