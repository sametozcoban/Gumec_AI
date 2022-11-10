using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.blue;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f , 0f);
    
    TextMeshPro _textMeshPro;
    Vector2Int _vector2Int = new Vector2Int();
    GridManager _gridManager;
    
   void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.enabled = false;
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UptadeObjectName();
        }
        
        SetLabelColor();
        ToggleCoordinates();

    }
    
    void DisplayCoordinates()
    {
        if(_gridManager == null){ return; }
        _vector2Int.x = Mathf.RoundToInt(transform.parent.position.x / _gridManager.UnityGridSize);
        _vector2Int.y = Mathf.RoundToInt(transform.parent.position.z / _gridManager.UnityGridSize);
        _textMeshPro.text = _vector2Int.x + "," +  _vector2Int.y;
    }

    void UptadeObjectName()
    {
        transform.parent.name = _vector2Int.ToString();
    }

    void SetLabelColor()
    {
        if(_gridManager == null){return;}

        Node node = _gridManager.GetNode(_vector2Int);
        
        if(node == null){return;}

        if (!node.isWalkable)
        {
            _textMeshPro.color = blockedColor;
        }
        else if(node.isExplored)
        {
            _textMeshPro.color = exploredColor;
        }
        else if(node.isPath)
        {
            _textMeshPro.color = pathColor;
        }
        else
        {
            _textMeshPro.color = defaultColor;
        }
    }

    void ToggleCoordinates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _textMeshPro.enabled = !_textMeshPro.IsActive();
        }
    }
}
