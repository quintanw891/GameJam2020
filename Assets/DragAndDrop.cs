using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 screenPos = new Vector3(mousePos.x, mousePos.y, 10);

        if(selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if(Input.GetMouseButtonUp(0))
            selected = false;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }
}
