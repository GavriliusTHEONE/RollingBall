using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 asd = new Vector3(0, 0, 5);
    bool updown = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updown){
            transform.position = transform.position - asd;
        }else {
            transform.position = transform.position + asd;
        }
        updown = !updown;
    }
}
