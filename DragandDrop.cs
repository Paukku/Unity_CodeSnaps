using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Jigsaw Puzzle game. Drag piece

public class DragandDrop : MonoBehaviour
{
    public GameObject selectPuzl;
    int OIL = 1;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.transform != null)
            {

                if (hit.transform.CompareTag("Puzzle"))
                {
                    if (!hit.transform.GetComponent<PieceScript>().InRightPosition)
                    {
                        selectPuzl = hit.transform.gameObject;
                        selectPuzl.GetComponent<PieceScript>().Selected = true;
                        selectPuzl.GetComponent<SortingGroup>().sortingOrder = OIL;
                        OIL++;
                    }

                    Rotate.instance.GetPuzzlePart(selectPuzl);          //viittaa rotate skriptiin jolla voi kääntää palaa
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectPuzl != null)
            {
                selectPuzl.GetComponent<PieceScript>().Selected = false;
                selectPuzl = null;
            }
            
        }

        if(selectPuzl != null)
        {
                Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                selectPuzl.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
        
    }
}
