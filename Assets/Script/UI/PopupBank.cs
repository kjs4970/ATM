using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank  : MonoBehaviour
{
    [Header("�г�")]
    public GameObject mainPanel;   // ����ȭ�� �г�
    public GameObject deposit;    // �Ա� �г�
    public GameObject withdrawal;    // ��� �г�

    [Header("����ȭ�� ��ư")]
    public Button btnShowDeposit;    // ����ȭ���� �Ա� ��ư
    public Button btnShowWithdraw;   // ����ȭ���� ��� ��ư

    [Header("�Ա� ����")]
    public Button [] btnDeposit; 
    public TMP_InputField inputDeposit;
    public Button btnDepositInput;

    [Header("��� ����")]
    public Button [] btnWithdraw;
    public TMP_InputField inputWithdraw;
    public Button btnWithdrawInput;

    [Header("����")]
    public Button btnBackD; // �Ա�ȭ�� �ڷΰ���
    public Button btnBackW; // ���ȭ�� �ڷΰ���
    public TextMeshProUGUI txtCash;
    public TextMeshProUGUI txtBalance;

    public UserData userData;


    void Start()
    {
        userData = GameManager.Instance.userData;

        // ���� ȭ�鿡�� �Ա�/��� ��ư
        btnShowDeposit.onClick.AddListener(ShowDepositPanel);
        btnShowWithdraw.onClick.AddListener(ShowWithdrawPanel);

        // �Ա�/��� ���� �Է�
        btnDepositInput.onClick.AddListener(OnDepositInputSubmit);
        btnWithdrawInput.onClick.AddListener(OnWithdrawInputSubmit);

        // �� ȭ�� �ڷΰ���
        btnBackD.onClick.AddListener(ShowMainPanel);
        btnBackW.onClick.AddListener(ShowMainPanel);

        //�Ա� test
        btnDeposit[0].onClick.AddListener(() => OnDeposit(10000));
        btnDeposit[1].onClick.AddListener(() => OnDeposit(30000));
        btnDeposit[2].onClick.AddListener(() => OnDeposit(50000));

        // ��� tset
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
            Debug.Log("1�� �̻� �Է��ϼ���!");
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
            Debug.Log("������ �����մϴ�.");
        }
    }

    void OnWithdraw(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("1�� �̻� �Է��ϼ���!");
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
            Debug.Log("�ܾ��� �����մϴ�.");
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
            Debug.Log("���ڸ� �Է��ϼ���!");
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
            Debug.Log("���ڸ� �Է��ϼ���!");
        }
        inputWithdraw.text = "";
    }


void RefreshUI()
    {
        GameManager.Instance.Refresh();
        txtCash.text = userData.GetFormattedCash() + "��";
        txtBalance.text = userData.GetFormattedBalance() + "��";
    }
}