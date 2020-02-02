using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool selecting;
    public GameObject selectedGroup;
    public PuzzlePiece selectedPiece;
    public bool canConnect;
    public int piecesCount;

    public Robot robot;

    public bool completed;
    // Start is called before the first frame update
    void Start()
    {
        selecting = true;
        canConnect = true;

        foreach (Transform child in gameObject.transform)
        {
            child.position = new Vector2( gameObject.transform.position.x + (Random.Range(-3f,3f)) , gameObject.transform.position.y + (Random.Range(-3f,3f)) );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedGroup != null && selectedGroup.transform.childCount == piecesCount) // create a win condition
        {
            Debug.Log("Puzzle Complete");
            robot.EnterBattle();
            Destroy(gameObject);
        }
    }
}
