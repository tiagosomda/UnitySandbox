using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPointClick : MonoBehaviour {

    private Camera cam;
    private NavMeshAgent nav;


    public Transform waypoint1;
    public Transform waypoint2;

    private Transform target;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        nav = GetComponent<NavMeshAgent>();

        target = waypoint2;

        nav.SetDestination(target.position);
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag.Equals("Node"))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = !hit.collider.gameObject.GetComponent<MeshRenderer>().enabled;
                    hit.collider.gameObject.GetComponent<NavMeshObstacle>().enabled = !hit.collider.gameObject.GetComponent<NavMeshObstacle>().enabled;
                }
            }
        }
	}

    private void FixedUpdate()
    {
        if (Vector3.Distance(target.position, transform.position) <= 0.3f)
        {
            if (target == waypoint1)
            {
                target = waypoint2;
            }
            else
            {
                target = waypoint1;
            }

            nav.SetDestination(target.position);
        }
    }
}
