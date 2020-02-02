using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool selected;
    public Puzzle puzzleManager;
    public GameObject puzzleGroup;
    public PuzzlePiece leftPiece;
    public bool leftConnected;
    public PuzzlePiece rightPiece;
    public bool rightConnected;
    public PuzzlePiece topPiece;
    public bool topConnected;
    public PuzzlePiece botPiece;
    public bool botConnected;

    private int lockRange = 1;
    private int distance = 1;

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
            if(puzzleGroup != null)
            {
                puzzleGroup.transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
            else
            {                
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
        }


        if (this == puzzleManager.selectedPiece || puzzleGroup == puzzleManager.selectedGroup)
        {
            
        if (rightPiece != null)
        {
            Transform rightTransform = rightPiece.gameObject.transform;

            if(rightConnected != true && puzzleManager.selecting == false)
            {
                if(((int)transform.position.x /lockRange) == ((int)rightTransform.position.x /lockRange)-distance
                && ((int)transform.position.y /lockRange) == ((int)rightTransform.position.y /lockRange))
                {
                    selected = false;
                    rightConnected = true;
                    rightPiece.leftConnected = true;
                    groupPuzzles(rightPiece, 'R');
                }
            }
        }

        if(leftPiece != null)
        {
            Transform leftTransform = leftPiece.gameObject.transform;

            if(leftConnected != true && puzzleManager.selecting == false)
            {
                if(((int)transform.position.x /lockRange) == ((int)leftTransform.position.x /lockRange)+distance
                && ((int)transform.position.y /lockRange) == ((int)leftTransform.position.y /lockRange))
                    {
                        selected = false;
                        leftConnected = true;
                        leftPiece.rightConnected = true;
                        groupPuzzles(leftPiece, 'L');
                    }
            }
        }
        

        if (topPiece != null)
        {
            Transform topTransform = topPiece.gameObject.transform;

            if(topConnected != true && puzzleManager.selecting == false)
            {
                if(((int)transform.position.x /lockRange) == ((int)topTransform.position.x /lockRange)
                && ((int)transform.position.y /lockRange) == ((int)topTransform.position.y /lockRange)-distance)
                {
                    selected = false;
                    topConnected = true;
                    topPiece.botConnected = true;
                    groupPuzzles(topPiece, 'T');
                }
            }
        }

        if (botPiece != null)
        {
            Transform botTransform = botPiece.gameObject.transform;

            if(botConnected != true && puzzleManager.selecting == false)
            {
                if(((int)transform.position.x /lockRange) == ((int)botTransform.position.x /lockRange)
                && ((int)transform.position.y /lockRange) == ((int)botTransform.position.y /lockRange)+distance)
                {
                    selected = false;
                    botConnected = true;
                    botPiece.topConnected = true;
                    groupPuzzles(botPiece , 'B');
                }
            }
        }
        }

    }

    void groupPuzzles(PuzzlePiece otherPiece, char c)
    {
        if(puzzleGroup == null && otherPiece.puzzleGroup == null)
        {
            GameObject newGroup = new GameObject();
            newGroup.transform.position = gameObject.transform.position;
            transform.SetParent(newGroup.transform);
            puzzleGroup = newGroup;
            otherPiece.gameObject.transform.SetParent(newGroup.transform);
            otherPiece.puzzleGroup = newGroup;

            if (c =='R')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x + distance, transform.position.y);
            }
            else if (c == 'L')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x - distance, transform.position.y);
            }
            else if (c == 'T')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x , transform.position.y + distance);
            }
            else if (c == 'B')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x , transform.position.y - distance);
            }
        }
        else if(puzzleGroup != null && otherPiece.puzzleGroup == null)
        {
            otherPiece.gameObject.transform.SetParent(puzzleGroup.transform);
            otherPiece.puzzleGroup = puzzleGroup;

            if (c =='R')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x + distance, transform.position.y);
            }
            else if (c == 'L')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x - distance, transform.position.y);
            }
            else if (c == 'T')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x , transform.position.y + distance);
            }
            else if (c == 'B')
            {
                otherPiece.gameObject.transform.position = new Vector2(transform.position.x , transform.position.y - distance);
            }
        }

        else if(puzzleGroup == null && otherPiece.puzzleGroup != null)
        {
            gameObject.transform.SetParent(otherPiece.puzzleGroup.transform);
            puzzleGroup = otherPiece.puzzleGroup;

            if (c =='R')
            {
                transform.position = new Vector2(otherPiece.gameObject.transform.position.x - distance, otherPiece.gameObject.transform.position.y);
            }
            else if (c == 'L')
            {
                transform.position = new Vector2(otherPiece.gameObject.transform.position.x + distance, otherPiece.gameObject.transform.position.y);
            }
            else if (c == 'T')
            {
                transform.position = new Vector2(otherPiece.gameObject.transform.position.x , otherPiece.gameObject.transform.position.y - distance);
            }
            else if (c == 'B')
            {
                transform.position = new Vector2(otherPiece.gameObject.transform.position.x , otherPiece.gameObject.transform.position.y + distance);
            }
        }

        else if(puzzleGroup != null && otherPiece.puzzleGroup != null)
        {
            int count = 0;
            foreach (Transform t in otherPiece.puzzleGroup.transform)
            {
                Debug.Log(count++);   
            }

            otherPiece.puzzleGroup.transform.parent = puzzleGroup.transform;

            for (int i = count - 1; i >= -1; i--)
            {
                otherPiece.puzzleGroup.transform.GetChild(0).GetComponent<PuzzlePiece>().puzzleGroup = puzzleGroup;
                otherPiece.puzzleGroup.transform.GetChild(0).parent = puzzleGroup.transform;
            }

            
            
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
            puzzleManager.selecting = true;
            puzzleManager.selectedPiece = this;
            if(puzzleGroup != null)
                puzzleManager.selectedGroup = puzzleGroup;
        }
    }

    void OnMouseUp()
    {
        selected = false;
        puzzleManager.selecting = false;
    }


}
