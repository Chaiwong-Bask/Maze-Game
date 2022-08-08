using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectTargets : MonoBehaviour
{
    [SerializeField] Transform[] destinations;
    [SerializeField] Transform current;

    private int i = 0;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = destinations[i].position;

    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(destinations[i].position, transform.position);
        current = destinations[i];
        //if npc reaches its destination...
        //if npc reaches its destination (or gets close)...
        if (dist < 1)
        {
            if (i < destinations.Length - 0)
            { //negate targets[0], since it's already set in destination.
                i++; //change next target
                _navMeshAgent.destination = destinations[i].position; //go to next target by setting it as the new destination
            }
        }
    }
}
