using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunter : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent Enemy;
    void Start()
    {
        Enemy = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector3.Distance(Target.transform.position, Enemy.transform.position) == 2)
        {
            Enemy.destination = Enemy.destination;
        }
        else
        {
            Enemy.destination = Target.transform.position;
        }*/
        Enemy.destination = Target.transform.position;
    }
}
