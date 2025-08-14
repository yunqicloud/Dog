using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUARD, PATROL, CHASE, DEAD}
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    public EnemyStates enermyStates;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        SwitchStates();
    }

    void SwitchStates()
    {
        switch (enermyStates)
        {
            case EnemyStates.GUARD:
                break;

            case EnemyStates.PATROL:
                break;

            case EnemyStates.CHASE:
                break;

            case EnemyStates.DEAD:
                break;
                
        }
    }
}
