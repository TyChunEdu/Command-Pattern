using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkMove : Command
{
    private Transform piece;

    private Transform movePoint;

    private float cellSize;

    private Vector3 direction;

    private int distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BlinkMove(Transform piece, Transform movePoint, float cellSize, Vector3 direction, int distance)
    {
        this.piece = piece;
        this.movePoint = movePoint;
        this.cellSize = cellSize;
        this.direction = direction;
        this.distance = distance;
    }

    public bool Do()
    {
        piece.position += direction * (cellSize * distance);
        movePoint.position += direction * (cellSize * distance);
        return true;
    }

    public bool Undo()
    {
        piece.position -= direction * (cellSize * distance);
        movePoint.position -= direction * (cellSize * distance);
        return true;
    }
}
