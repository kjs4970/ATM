using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank  : MonoBehaviour
{
    [Header("패널")]
    public GameObject mainPanel;   // 메인화면 패널
    public GameObject deposit;    // 입금 패널
    public GameObject withdrawal;    // 출금 패널

    [Header("메인화면 버튼")]
    public Button btnShowDeposit;    // 메인화면의 입금 버튼
    public Button btnShowWithdraw;   // 메인화면의 출금 버튼

    [Header("입금 관련")]
    public Button [] btnDeposit; 
    public TMP_InputField inputDeposit;
    public Button btnDepositInput;

    [Header("출금 관련")]
    public Button [] btnWithdraw;
    public TMP_InputField inputWithdraw;
    public Button btnWithdrawInput;

    [Header("공통")]
    public Button btnBackD; // 입금화면 뒤로가기
    public Button btnBackW; // 출금화면 뒤로가기
    public TextMeshProUGUI txtCash;
    public TextMeshProUGUI txtBalance;

    public UserData userData;


    void Start()
    {
        userData = GameManager.Instance.userData;

        // 메인 화면에서 입금/출금 버튼
        btnShowDeposit.onClick.AddListener(ShowDepositPanel);
        btnShowWithdraw.onClick.AddListener(ShowWithdrawPanel);

        // 입금/출금 직접 입력
        btnDepositInput.onClick.AddListener(OnDepositInputSubmit);
        btnWithdrawInput.onClick.AddListener(OnWithdrawInputSubmit);

        // 각 화면 뒤로가기
        btnBackD.onClick.AddListener(ShowMainPanel);
        btnBackW.onClick.AddListener(ShowMainPanel);

        //입금 test
        btnDeposit[0].onClick.AddListener(() => OnDeposit(10000));
        btnDeposit[1].onClick.AddListener(() => OnDeposit(30000));
        btnDeposit[2].onClick.AddListener(() => OnDeposit(50000));

        // 출금 tset
        btnWithdraw[0].onClick.AddListener(() => OnWithdraw(10000));
        btnWithdraw[1].onClick.AddListener(() => OnWithdraw(30000));
        btnWithdraw[2].onClick.AddListener(() => OnWithdraw(50000));

        RefreshUI();
        ShowMainPanel();
        
    }

    void ShowMainPanel()
    {
        GameManager.Instance.Refresh();
        mainPanel.SetActive(true);
        deposit.SetActive(false);
        withdrawal.SetActive(false);
    }

    void ShowDepositPanel()
    {
        GameManager.Instance.Refresh();
        mainPanel.SetActive(false);
        deposit.SetActive(true);
        withdrawal.SetActive(false);
    }

    void ShowWithdrawPanel()
    {
        GameManager.Instance.Refresh();
        mainPanel.SetActive(false);
        deposit.SetActive(false);
        withdrawal.SetActive(true);

    }
    void OnDeposit(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("1원 이상 입력하세요!");
            return;
        }
        if (userData.Cash >= amount)
        {
            userData.Deposit(amount);
            GameManager.Instance.SaveUserData();
            ShowMainPanel();
            GameManager.Instance.Refresh();
        }
        else
        {
            Debug.Log("현금이 부족합니다.");
        }
    }

    void OnWithdraw(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("1원 이상 입력하세요!");
            return;
        }
        if (userData.Balance >= amount)
        {
            userData.Withdraw(amount);
            GameManager.Instance.SaveUserData();
            ShowMainPanel();
            GameManager.Instance.Refresh();
        }
        else
        {
            Debug.Log("잔액이 부족합니다.");
        }
    }

    void OnDepositInputSubmit()
    {
        int amount;
        if (int.TryParse(inputDeposit.text, out amount))
        {
            OnDeposit(amount);
        }
        else
        {
            Debug.Log("숫자를 입력하세요!");
        }
        inputDeposit.text = "";
    }

    void OnWithdrawInputSubmit()
    {
        int amount;
        if (int.TryParse(inputWithdraw.text, out amount))
        {
            OnWithdraw(amount);
        }
        else
        {
            Debug.Log("숫자를 입력하세요!");
        }
        inputWithdraw.text = "";
    }


void RefreshUI()
    {
        GameManager.Instance.Refresh();
        txtCash.text = userData.GetFormattedCash() + "원";
        txtBalance.text = userData.GetFormattedBalance() + "원";
    }
}