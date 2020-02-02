using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedGroup;
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
            if(selectedGroup != null)
            {
                selectedGroup.transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
            else
            {                
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
        }

            
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    void OnMouseUp()
    {
        selected = false;
    }


}
