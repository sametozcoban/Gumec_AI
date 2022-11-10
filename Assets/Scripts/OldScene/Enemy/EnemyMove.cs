using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    List<Node> path = new List<Node>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy _enemy;

    GridManager _gridManager;
    PathFinder _pathFinder;
    // Start is called before the first frame update
    void OnEnable()
    {
        RecalculatePath(true);
        ReturnToStart();
    }

    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _gridManager = FindObjectOfType<GridManager>();
        _pathFinder = FindObjectOfType<PathFinder>();
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = _pathFinder.StartCoordinates;
        }
        else
        {
            coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);
        }
        
        StopAllCoroutines();
        path.Clear();
        path = _pathFinder.GetNewPath(coordinates);
        StartCoroutine(FollowingPath());
    }

    void ReturnToStart()
    {
        transform.position = _gridManager.GetPosition(_pathFinder.StartCoordinates);
    }

    void FinishPath()
    {
        _enemy.GoldPenalty();
        gameObject.SetActive(false);
    }

    IEnumerator FollowingPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            
            Vector3 starPosition = transform.position;
            Vector3 endPosition = _gridManager.GetPosition(path[i].coordinates);
            float timeLEPS = 0f;
            transform.LookAt(endPosition);

            while (timeLEPS < 1f)
            {
                timeLEPS += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(starPosition, endPosition, timeLEPS);
                yield return new WaitForEndOfFrame();
            }
        }
       FinishPath();
    }
}
