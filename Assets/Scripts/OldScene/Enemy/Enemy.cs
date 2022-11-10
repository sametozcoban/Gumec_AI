using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]  int goldReward = 25;
    [SerializeField]  int goldPenalty = 25;

    Bank _bank;
    // Start is called before the first frame update
    void Awake()
    {
        _bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void GoldReward()
    //{
    //    _bank.CurrentBalance += goldReward;
    //}

    //void GoldPenalty()
    //{
    //    _bank.CurrentBalance -= goldPenalty;
    //}

    public void GoldReward()
    {
        if(_bank == null){return;}
        _bank.Deposit(goldReward);
    }

    public void GoldPenalty()
    {
        if(_bank == null){return;}
        _bank.Withdraw(goldPenalty);
    }
}
