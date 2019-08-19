using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public Vector2 v;
    public Vector2 Dv;
    public float speed;

    public int NumbMeth;

    public GameObject Rocket;
    public GameObject PlaneCopy;
    float time = 0;

    // Use this for initialization
    void Start()
    {
        v = transform.position;
        speed = Random.Range(0.2f, 0.4f);
        NumbMeth = Random.Range(0, 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (transform.position.x < -24 || transform.position.x > 24 || transform.position.y < -12 || transform.position.y > 12)
        {
            Vector2 pos;
            pos.x = Random.Range(-24, 24);
            pos.y = Random.Range(-12, 12);
            transform.position = pos;

            NumbMeth = Random.Range(0, 4);

            GameObject Point = GameObject.FindGameObjectWithTag("Point");
            Rocket = GameObject.FindGameObjectWithTag("Rocket");
            Destroy(Point);
            Destroy(Rocket);
        }
        if (NumbMeth == 0)
            Forvard();
        if (NumbMeth == 1)
            ForvardUp();
        if (NumbMeth == 2)
            ForvardDown();
        if (NumbMeth == 3)
            Sinus();
        if (NumbMeth == 4)
            Center();
    }

    void Forvard()
    {
        transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
        //transform.position += transform.up * speed * Time.deltaTime;
        //Vector2 v2 = transform.position;
        //v2.x += speed * Time.deltaTime;

        //transform.position = new Vector3(v2.x, v2.y, 0);
    }

    void ForvardUp()
    {
        //transform.Translate(Vector3.up * Time.deltaTime * speed);
        //transform.position += transform.up * speed * Time.deltaTime;
        Vector2 v2 = transform.position;
        v2.x += speed * Time.deltaTime;
        v2.y += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, RotationGradWithRotat(v2, this.gameObject));
        transform.position = new Vector3(v2.x, v2.y, 0);
    }
    void ForvardDown()
    {
        //transform.Translate(Vector3.up * Time.deltaTime * speed);
        //transform.position += transform.up * speed * Time.deltaTime;
        Vector2 v2 = transform.position;
        v2.x += speed * Time.deltaTime;
        v2.y -= speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, RotationGradWithRotat(v2, this.gameObject));
        transform.position = new Vector3(v2.x, v2.y, 0);

    }

    void Rotate()
    {
        gameObject.transform.position += transform.up * speed * Time.deltaTime;
        if (Time.time != 0)
            Dv = (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - v) / Time.time;
        gameObject.transform.Rotate(Dv);
    }

    void Center()
    {
        Vector3[] point = new Vector3[] { new Vector3(0, 0, 0), new Vector3(5, 3, 0) };
        //float radius = Vector3.Distance(gameObject.transform.position, new Vector3(0, 0, 0));
        //float a = Mathf.Pow(speed, 2) / radius;
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        Vector3 target = point[0] - transform.position;
        Quaternion direct = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(RotationGrad(point[0], this.gameObject), Vector3.forward), speed * Time.deltaTime);
    }

    void Sinus()
    {
        Vector2 pos = new Vector2();

        pos.x = transform.position.x + speed * Time.deltaTime;
        pos.y = transform.position.y + Mathf.Sin(pos.x) * Time.deltaTime;

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(RotationGradWithRotat(pos, this.gameObject), Vector3.forward), 1);
        transform.position = pos;
    }


    float RotationGrad(Vector2 pos, GameObject plane)//поворот в строну объекта
    {
        float dX = pos.x - plane.transform.position.x;
        float dY = pos.y - plane.transform.position.y;

        float rot = Mathf.Atan2(dY, dX) * Mathf.Rad2Deg;                  //перевод радиан в градуси и -90 поворот спрайта
        return rot;
    }
    float RotationGradWithRotat(Vector2 pos, GameObject plane)//поворот в строну объекта
    {
        float dX = pos.x - plane.transform.position.x;
        float dY = pos.y - plane.transform.position.y;

        float rot = Mathf.Atan2(dY, dX) * Mathf.Rad2Deg - 90;                  //перевод радиан в градуси и -90 поворот спрайта
        return rot;
    }
}
