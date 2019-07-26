using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public GameObject Plane;
    public GameObject PlaneCopy;
    public int speed = 1;

    Vector2 pos;
	
	void Update () {
        Plane = GameObject.FindGameObjectWithTag("Plane");

        transform.position = Vector3.MoveTowards(transform.position, Plane.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, Plane.transform.position) == 0)
        {
            pos.x = Random.Range(-10, 10);
            pos.y = Random.Range(-10, 10);

            Destroy(gameObject);
            Destroy(Plane);
            Instantiate(PlaneCopy, pos, Quaternion.identity);
        }
            
	}
}
