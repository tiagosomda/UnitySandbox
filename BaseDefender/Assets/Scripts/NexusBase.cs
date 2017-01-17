﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusBase : MonoBehaviour {
    public int life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            life--;
            Destroy(other.gameObject);
        }
    }
}