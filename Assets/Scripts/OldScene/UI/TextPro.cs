using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class TextPro : MonoBehaviour
{
    [SerializeField]  TMP_Text _textMeshPro;
    Bank _bank;
    // Start is called before the first frame update
    void Start()
    {
        _bank = FindObjectOfType<Bank>();
        _textMeshPro = GetComponent<TMP_Text>();
        _textMeshPro.text= "Start";
    }

    private void Update()
    {
        UIPro();
    }

    public bool UIPro()
    {
        if (_bank == null)
        {
            return false;
        }
        _textMeshPro.text ="GOLD : " + _bank.CurrentBalance.ToString();
        return true;
    }
}
