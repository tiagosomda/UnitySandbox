using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGrid : MonoBehaviour {

    public int gridX;
    public int gridY;
    public GameObject tile;


    private Camera cam;

    private float mapX;
    private float mapY;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float screenWidth;
    private float screenHeight;

    // Use this for initialization
    void Start () {
        UpdateCameraValues();

        //var square = Instantiate(tile, GetPosition(0, 0), Quaternion.identity, transform);
        //square.transform.position = new Vector3(maxX, minY, 10f);

        

        for (int i = 0; i < gridX; i++)
        {
            for(int j = 0; j < gridY; j++)
            {
                Instantiate(tile, GetPosition(i, j), Quaternion.identity, transform);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3 GetPosition(int i, int j)
    {
        var posX = maxX + (i);
        var posY = minY - (j);

        var pos = new Vector2(posX, posY);

        return pos;
    }


    void UpdateCameraValues()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }
}
