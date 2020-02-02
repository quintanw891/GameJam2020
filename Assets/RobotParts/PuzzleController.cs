using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public Puzzle puzzlePrefab;
    public Robot robot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPuzzle()
    {
        Puzzle newPuzzle = Instantiate(puzzlePrefab);
        newPuzzle.gameObject.transform.position = new Vector3(-6,3,0);
        newPuzzle.robot = robot;
    }
}
