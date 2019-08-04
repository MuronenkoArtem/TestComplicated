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

    float time = 0;

    // Use this for initialization
    void Start()
    {
        v = transform.position;
        speed = Random.Range(0.2f, 0.4f);
        NumbMeth = Random.Range(0, 1);


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Rocket = GameObject.FindGameObjectWithTag("Rocket");
        if (Rocket == true)
        {
            float dist = Vector3.Distance(transform.position, Rocket.transform.position);

        }
        if (NumbMeth == 0)
            Forvard(this.gameObject);
        else
            Rotate(this.gameObject);
    }

    void Forvard(GameObject gameObject)
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //transform.position += transform.up * speed * Time.deltaTime;
    }

    void Rotate(GameObject gameObject)
    {
        gameObject.transform.position += transform.up * speed * Time.deltaTime;
        if (Time.time != 0)
            Dv = (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - v) / Time.time;
        gameObject.transform.Rotate(Dv);
    }
}
