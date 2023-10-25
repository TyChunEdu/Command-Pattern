using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RealMove : Command
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

    public RealMove(Transform piece, Transform movePoint, float cellSize, Vector3 direction, int distance)
    {
        this.piece = piece;
        this.movePoint = movePoint;
        this.cellSize = cellSize;
        this.direction = direction;
        this.distance = distance;
    }

    public bool Do()
    {
        if (Vector3.Distance(piece.position, movePoint.position) < 0.5f)
        {
            movePoint.position += direction * (cellSize * distance);
            return true;
        }

        return false;
    }

    public bool Undo()
    {
        if (Vector3.Distance(piece.position, movePoint.position) < 0.5f)
        {
            movePoint.position -= direction * (cellSize * distance);
            return true;
        }

        return false;
    }
}
