using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGrid : MonoBehaviour {

    public float snapValue = 1;
    public float depth = 0;

    public GameObject square;
    public Transform mapTiles;

    public List<Vector3> placedTiles;

    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        placedTiles = new List<Vector3>();

        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //var pos = Input.mousePosition;
        //transform.position = GetGridPos(pos);

        SnapPos();

        if(placedTiles.Contains(transform.position))
        {
            sprite.color = Color.red;
            return;
        }
        else
        {
            sprite.color = Color.white;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(transform.position);
            PlaceSquare();
        }

    }

    void PlaceSquare()
    {
        Instantiate(square, transform.position, Quaternion.identity, mapTiles);
        placedTiles.Add(transform.position);
    }

    void SnapPos()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float snapInverse = 1 / snapValue;

        float x, y, z;

        // if snapValue = .5, x = 1.45 -> snapInverse = 2 -> x*2 => 2.90 -> round 2.90 => 3 -> 3/2 => 1.5
        // so 1.45 to nearest .5 is 1.5
        x = Mathf.Round(pos.x * snapInverse) / snapInverse;
        y = Mathf.Round(pos.y * snapInverse) / snapInverse;
        z = depth + 10;  // depth from camera

        transform.position = new Vector3(x, y, z);
    }
}
