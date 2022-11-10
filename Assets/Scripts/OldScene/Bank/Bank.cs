using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
   [SerializeField] int startingBalance = 750;
   [SerializeField] int currentBalance;

   HealthEnemy _healthEnemy;
   //public int CurrentBalance
   //{
   //   get { return currentBalance; }
   //   set => currentBalance = value;
   //}

   public int CurrentBalance { get { return currentBalance; }}
   void Awake()
   {
      currentBalance = startingBalance;
   }

   void Start()
   {
      _healthEnemy = FindObjectOfType<HealthEnemy>();
   }

   public void Deposit(int amount)
   {
      currentBalance += Mathf.Abs(amount);
   }

   public void Withdraw(int amount)
   {
      currentBalance -= Mathf.Abs(amount);
      if (currentBalance < 0)
      {
         ReloadLevel();
      }
   }

   void ReloadLevel()
   {
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(sceneIndex);
   }
}
