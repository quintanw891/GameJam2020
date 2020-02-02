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

    private float lockRange = 1f;
    private float distance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition; // Allow for item to follow mouse
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


        if (this == puzzleManager.selectedPiece || puzzleGroup == puzzleManager.selectedGroup) // check to see if a piece is next to another
        {
            
        if (rightPiece != null)
        {
            Transform rightTransform = rightPiece.gameObject.transform;

            if(rightConnected != true && puzzleManager.selecting == false)
            {
                if( ( (Mathf.Round(transform.position.x * lockRange)/lockRange) == ((Mathf.Round(rightTransform.position.x * lockRange)/lockRange)-distance ) )
                && ( (Mathf.Round(transform.position.y * lockRange)/lockRange) == ((Mathf.Round(rightTransform.position.y * lockRange)/lockRange)) ) ) 
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
                if( ( (Mathf.Round(transform.position.x * lockRange)/lockRange) == ((Mathf.Round(leftTransform.position.x * lockRange)/lockRange)+distance ) )
                && ( (Mathf.Round(transform.position.y * lockRange)/lockRange) == ((Mathf.Round(leftTransform.position.y * lockRange)/lockRange)) ) ) 
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
                if( ( (Mathf.Round(transform.position.x * lockRange)/lockRange) == ((Mathf.Round(topTransform.position.x * lockRange)/lockRange)) )
                && ( (Mathf.Round(transform.position.y * lockRange)/lockRange) == ((Mathf.Round(topTransform.position.y * lockRange)/lockRange)-distance) ) ) 
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
                if( ( (Mathf.Round(transform.position.x * lockRange)/lockRange) == ((Mathf.Round(botTransform.position.x * lockRange)/lockRange)) )
                && ( (Mathf.Round(transform.position.y * lockRange)/lockRange) == ((Mathf.Round(botTransform.position.y * lockRange)/lockRange)+distance) ) ) 
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

    void groupPuzzles(PuzzlePiece otherPiece, char c) // group connected piece to a single GameObject and lock the pieces to eachother
    {
        if (puzzleManager.canConnect == true && (puzzleGroup != otherPiece.puzzleGroup || puzzleGroup == null))
        {
            puzzleManager.canConnect = false;

        if(puzzleGroup == null && otherPiece.puzzleGroup == null)
        {
            GameObject newGroup = new GameObject();
            newGroup.transform.position = gameObject.transform.position;
            newGroup.transform.parent = puzzleManager.gameObject.transform;
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

            GameObject toBeDestroyed = otherPiece.puzzleGroup;
            int count = toBeDestroyed.transform.childCount;

            while (count > 0)
            {
                PuzzlePiece piece = toBeDestroyed.transform.GetChild(count - 1).GetComponent<PuzzlePiece>();
                piece.puzzleGroup = puzzleGroup;
                piece.gameObject.transform.parent = puzzleGroup.transform;
                count--;
            }

            Destroy(toBeDestroyed);
            
        }
            puzzleManager.canConnect = true;
        }
    }

    void OnMouseOver() //determine when to start dragging
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

    void OnMouseUp() //determin when to stop dragging
    {
        selected = false;
        puzzleManager.selecting = false;
    }


}
