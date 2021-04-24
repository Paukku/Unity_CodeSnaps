using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Jiggsaw puzzle game.

public class Select : MonoBehaviour
{

    private Vector2 initialPosition; // jos halutaan palauttaa pala takaisin omalle paikalle
    private Vector2 mousePosition;
    private float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

    }

    private void OnMouseDown()
    {
       
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        

        Rotate.instance.GetPuzzlePart(gameObject);

    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        
        
    }
}
