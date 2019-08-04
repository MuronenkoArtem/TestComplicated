using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public GameObject roc;
    void Start()
    {
        Instantiate(roc, transform.position, Quaternion.identity);
    }
	void OnMouseDown()
    {
        Instantiate(roc, transform.position, Quaternion.identity);
    }
}
