using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;
    bool going_to_a;
    public float MoveSpeed = 1;
    public float time_to_wait = 0;

    // Use this for initialization
    void Start () {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 my_pos = this.transform.position;
        Vector3 target;
        if (going_to_a)
        {
            target = this.pointA;
        }
        else
        {
            target = this.pointB;
        }
        if (isArrived(my_pos, target))
        {
            going_to_a = !going_to_a;
            return;
        }
        Vector3 destination = target - my_pos;
        destination.z = 0;
       // Vector3 move = destination.normalized*MoveSpeed*( time_to_wait);
        Vector3 move = destination.normalized*MoveSpeed* -Time.deltaTime;
        if (move.magnitude > destination.magnitude)
        {
            move = destination;
        }
        this.transform.position = my_pos - move;

        //float time_to_wait = 0;
        if (time_to_wait <= 0)
        {
            time_to_wait -= Time.deltaTime;
            return;
        }
    }

    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        //return Vector3.Distance(pos, target) < 0.2f;
        return Vector3.Distance(pos, target) < 0.02f;
    }


}
