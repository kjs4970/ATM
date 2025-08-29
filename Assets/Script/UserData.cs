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

    // 천 단위 콤마가 포함된 문자열 반환
    public string GetFormattedCash()
    {
        return string.Format("{0:N0}", Cash);
    }

    public string GetFormattedBalance()
    {
        return string.Format("{0:N0}", Balance);
    }

    //현금 입금
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
