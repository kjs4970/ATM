using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    
    public string UserName;
    public int Cash;
    public int Balance;

    public UserData(string userName, int cash, int balance)
    {
        UserName = userName;
        Cash = cash;
        Balance = balance;
    }

    // õ ���� �޸��� ���Ե� ���ڿ� ��ȯ
    public string GetFormattedCash()
    {
        return string.Format("{0:N0}", Cash);
    }

    public string GetFormattedBalance()
    {
        return string.Format("{0:N0}", Balance);
    }

    //���� �Ա�
    public bool Deposit(int amount)
    {
        if (Cash >= amount && amount > 0)
        {
            Cash -= amount;
            Balance += amount;
            return true;
        }
        return false;
    }

    public bool Withdraw(int amount)
    {
        if (Balance >= amount && amount > 0)
        {
            Balance -= amount;
            Cash += amount;
            return true;
        }
        return false;
    }
}
