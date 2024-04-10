using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.destination = Board.instance.getExitPos();
    }
}
