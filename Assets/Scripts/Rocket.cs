using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public GameObject Plane;
    public GameObject PlaneCopy;
    public int speed = 1;
    public GameObject Point;

    Vector2 pos;

    float time = 0;

    void Start()
    {
        Plane = GameObject.FindGameObjectWithTag("Plane");
        float dist = Vector3.Distance(transform.position, Plane.transform.position);

        //Instantiate(Point, Plane.transform.position + (dist * Plane.GetComponent<Plane>().speed, Quaternion.identity);
        Debug.Log(Plane.transform.position.x * Time.time + " " + Time.time + " " + dist + " " + Plane.GetComponent<Plane>().speed);
    }

    void Update()
    {
        time += Time.deltaTime;

        Plane = GameObject.FindGameObjectWithTag("Plane");
        //Debug.Log(Plane.transform.position.x * time);

        transform.position = Vector3.MoveTowards(transform.position, Plane.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, Plane.transform.position) == 0)
        {
            pos.x = Random.Range(-10, 10);
            pos.y = Random.Range(-10, 10);

            Destroy(gameObject);
            Destroy(Plane);
            Debug.Log(time + " " + Time.time + " " + Plane.transform.position);
            Instantiate(PlaneCopy, pos, Quaternion.Euler(0, 0, -90));

            time = 0;
        }


    }
}
