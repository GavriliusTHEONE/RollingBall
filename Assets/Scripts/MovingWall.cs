using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public float min = 0;
    public float max = 0;
    public GameObject movingwall;
    public GameObject barrierleft;
    public GameObject barrierright;
    Vector3 move = new Vector3(0.2f, 0, 0);
    Vector3 dest = new Vector3(9.75f, 1.75f, -0.25f);
    Vector3 startpos = new Vector3(-9.5f, 1.75f, -0.25f);
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("barrier"))
        {
            //movingwall.transform.position = movingwall.transform.position - move;
        }
        //transform rightside = (9.39, 2.16, -0.24);
        //right = new Transform(9.39, 2.16, -0.24);
        // Start is called before the first frame update
        void Start()
        {
            min = movingwall.transform.position.x;
            max = dest.x;
            //Vector3 startpos = movingwall.transform.position;
            
            //float leftside = Input.GetAxis("Vertical");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movingwall.transform.position = Vector3.Lerp(startpos, dest, Mathf.PingPong(Time.time, 1));
        //movingwall.transform.position = new Vector3(Mathf.PingPong(1, max-min), transform.position.y, transform.position.z);
        //if (movingwall.transform.position == startpos)
        //{
        //    movingwall.transform.position = Vector3.Lerp(startpos, dest, 1f);
        // }
        //if (movingwall.transform.position == dest)
        //{
        //     movingwall.transform.position = Vector3.Lerp(dest, startpos, 1f);
        //}
        //movingwall.transform.position = movingwall.transform.position + move;
        /*if (movingwall.transform.position == rightside)
        {
            movingwall.transform.position = movingwall.transform.position - move;
        }
        if (movingwall.transform.position.x == leftside)
        {
            movingwall.transform.position = movingwall.transform.position + move;
        }*/
    }

}
