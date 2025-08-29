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

        savePath = Path.Combine(Application.persistentDataPath, "userdata_홍길동.json");
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
        Debug.Log("저장됨: " + savePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("로드됨: " + savePath);
        }
        else
        {
            userData = new UserData("홍길동", 100000, 50000);
            Debug.Log("기본값 생성");
        }
    }

    public void Refresh()
    {

     name[0].text = userData.UserName;
     name[1].text = userData.UserName;
     name[2].text = userData.UserName;

     cash[0].text = userData.GetFormattedCash() + "원";
     cash[1].text = userData.GetFormattedCash() + "원";
     cash[2].text = userData.GetFormattedCash() + "원";

     balance[0].text = userData.GetFormattedBalance() + "원";
     balance[1].text = userData.GetFormattedBalance() + "원";
     balance[2].text = userData.GetFormattedBalance() + "원";

    }


}
