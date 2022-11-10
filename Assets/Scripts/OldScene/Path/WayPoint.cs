using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
   [SerializeField] Target towerPrefab;
   [SerializeField] bool isPlaceable;
   
   public bool IsPlaceable { get { return isPlaceable; } }

   GridManager _gridManager;
   PathFinder _pathFinder;
   Vector2Int coordinates = new Vector2Int();

   void Awake()
   {
      _gridManager = FindObjectOfType<GridManager>();
      _pathFinder = FindObjectOfType<PathFinder>();
   }

   void Start()
   {
      if (_gridManager != null)
      {
         coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);

         if (!isPlaceable)
         {
            _gridManager.BlockNode(coordinates);
         }
      }
   }

   void OnMouseDown()
   {
      if (_gridManager.GetNode(coordinates).isWalkable && !_pathFinder.WillBlockPath(coordinates) )
      {
         bool isSuccesful = towerPrefab.CreateTarget(towerPrefab, transform.position);
         if (isSuccesful)
         {
            _gridManager.BlockNode(coordinates);
            _pathFinder.NotifyReceivers();
         }
      }
   }
}
