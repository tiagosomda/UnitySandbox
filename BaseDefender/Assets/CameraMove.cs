using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var pos = Input.mousePosition;

        Debug.Log(pos);
        var p = transform.position;
        if(pos.x < 50 && pos.x > 0)
        {
            p.x -= speed * Time.deltaTime;
        }

        if (pos.x > Screen.width - 50 && pos.x < Screen.width)
        {
            p.x += speed * Time.deltaTime;
        }

        if (pos.y < 50 && pos.y > 0)
        {
            p.z -= speed * Time.deltaTime;
        }

        if (pos.y > Screen.height - 50 & pos.y < Screen.height)
        {
            p.z += speed * Time.deltaTime;
        }

        if(p.z > 25f)
        {
            p.z = 25.00f;
        }

        if(p.z < -25.0f)
        {
            p.z = -25.00f;
        }

        if (p.x > 45f)
        {
            p.x = 45.00f;
        }

        if (p.x < -45.0f)
        {
            p.x = -45.00f;
        }

        transform.position = p;

    }
}
