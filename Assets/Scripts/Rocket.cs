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
    Vector2 posR;

    float time = 0;

    void Start()
    {
        Plane = GameObject.FindGameObjectWithTag("Plane");
        posR = transform.position;
        SinusPoint();

        //Debug.Log(Plane.transform.position.x * Time.time + " " + Time.time + " " + dist + " " + Plane.GetComponent<Plane>().speed);        
    }
    void Update()
    {
        time += Time.deltaTime;

        Plane = GameObject.FindGameObjectWithTag("Plane");

        transform.rotation = Quaternion.Euler(0, 0, RotationGrad(Plane, this.gameObject));
        transform.position = Vector3.MoveTowards(transform.position, Plane.transform.position, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == "Plane")
        {
            pos.x = Random.Range(-24, 24);
            pos.y = Random.Range(-12, 12);

            Destroy(gameObject);
            Destroy(Plane);
            Point = GameObject.FindGameObjectWithTag("Point");
            Destroy(Point);
            Instantiate(PlaneCopy, pos, Quaternion.Euler(0, 0, -90));

            time = 0;
        }
    }

    void ForvardPoint()
    {
        float dist = Vector3.Distance(transform.position, Plane.transform.position);
        float t = dist / (speed + Plane.GetComponent<Plane>().speed);
        float S = t * Plane.GetComponent<Plane>().speed + Plane.transform.position.x;

        Vector3 pos;
        pos.x = S;
        pos.y = Plane.transform.position.y;
        pos.z = 0;

        Instantiate(Point, pos, Quaternion.identity);

    }

    void ForvardUpPoint()
    {
        float dist = Vector3.Distance(transform.position, Plane.transform.position);
        float t = dist / (speed + Plane.GetComponent<Plane>().speed);
        float S = t * Plane.GetComponent<Plane>().speed + Plane.transform.position.x;

        Debug.Log(dist);

        Vector2 v;
        v.x = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.x;
        v.y = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.y;



        dist = dist + Mathf.Abs(dist - Vector3.Distance(new Vector2(0, 0), v));

        t = dist / (speed + Plane.GetComponent<Plane>().speed);

        v.x = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.x;
        v.y = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.y;
        Debug.Log(dist);

        Instantiate(Point, v, Quaternion.identity);
    }
    void SinusPoint()
    {
        float dist = Vector3.Distance(transform.position, Plane.transform.position);
        float t = dist / (speed + Plane.GetComponent<Plane>().speed);
        float S = t * Plane.GetComponent<Plane>().speed + Plane.transform.position.x;

        Vector3 pos;
        pos.x = S;
        pos.y = Plane.transform.position.y + Mathf.Sin(pos.x) * Time.deltaTime;
        pos.z = 0;

        Debug.Log(t);

        Instantiate(Point, pos, Quaternion.identity);
    }
    void ForvardDowPoint()
    {
        float dist = Vector3.Distance(transform.position, Plane.transform.position);
        float t = dist / (speed + Plane.GetComponent<Plane>().speed);
        float S = t * Plane.GetComponent<Plane>().speed + Plane.transform.position.x;

        Vector2 v;
        v.x = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.x;
        v.y = Plane.transform.position.y - (t * Plane.GetComponent<Plane>().speed);

        dist = dist + Mathf.Abs(dist - Vector3.Distance(new Vector2(0, 0), v));

        t = dist / (speed + Plane.GetComponent<Plane>().speed);

        v.x = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.x;
        v.y = Plane.transform.position.y - (t * Plane.GetComponent<Plane>().speed);

        Instantiate(Point, v, Quaternion.identity);
    }

    void CenterPoint()
    {
        float dist = Vector3.Distance(transform.position, Plane.transform.position);
        float t = dist / (speed + Plane.GetComponent<Plane>().speed);
        float S = t * Plane.GetComponent<Plane>().speed + Plane.transform.position.x;

        Debug.Log(dist);

        Vector2 v;
        v.x = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.x;
        v.y = (t * Plane.GetComponent<Plane>().speed) + Plane.transform.position.y;

        Instantiate(Point, v, Quaternion.identity);
    }
    float RotationGrad(GameObject plane, GameObject rocket)//поворот в строну объекта
    {
        float dX = plane.transform.position.x - rocket.transform.position.x;
        float dY = plane.transform.position.y - rocket.transform.position.y;

        float rot = Mathf.Atan2(dY, dX) * Mathf.Rad2Deg - 55;                  //перевод радиан в градуси и -55 поворот спрайта
        return rot;
    }
}
