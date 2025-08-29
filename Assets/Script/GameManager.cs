using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI[] name;   
    public TextMeshProUGUI[] cash;
    public TextMeshProUGUI[] balance;

    public static GameManager Instance;
    public UserData userData;

    private string savePath;

    void Awake()
    {
        Instance = this;

        savePath = Path.Combine(Application.persistentDataPath, "userdata_ȫ�浿.json");
        LoadUserData();
    }

    void Start()
    {
        Refresh();
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        File.WriteAllText(savePath, json);
        Debug.Log("�����: " + savePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("�ε��: " + savePath);
        }
        else
        {
            userData = new UserData("ȫ�浿", 100000, 50000);
            Debug.Log("�⺻�� ����");
        }
    }

    public void Refresh()
    {

     name[0].text = userData.UserName;
     name[1].text = userData.UserName;
     name[2].text = userData.UserName;

     cash[0].text = userData.GetFormattedCash() + "��";
     cash[1].text = userData.GetFormattedCash() + "��";
     cash[2].text = userData.GetFormattedCash() + "��";

     balance[0].text = userData.GetFormattedBalance() + "��";
     balance[1].text = userData.GetFormattedBalance() + "��";
     balance[2].text = userData.GetFormattedBalance() + "��";

    }


}
