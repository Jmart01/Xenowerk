using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingComponent : MonoBehaviour
{
    [SerializeField] GameObject[] PatrolPoints;
    private int NextPatrolPointIndex = 0;

    public GameObject GetNextPatrolPoint()
    {
        if (PatrolPoints.Length > NextPatrolPointIndex)
        { 
            GameObject patrolPoint = PatrolPoints[NextPatrolPointIndex];
            NextPatrolPointIndex = (NextPatrolPointIndex + 1) % PatrolPoints.Length;
            return patrolPoint;
        }
        return null;
    }
}
