using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

    public GameObject ground;
    private bool walking = false;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }
		if(walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * 0.5f * Time.deltaTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.name.Contains("plane"))
            {
                walking = false;
            } else
            {
                walking = true;
            }
        }
	}
}
