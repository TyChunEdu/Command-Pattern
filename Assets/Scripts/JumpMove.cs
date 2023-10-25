using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMove : Command
{
    private Transform piece;

    private Transform movePoint;

    private float cellSize;

    public JumpMove(Transform piece, Transform movePoint, float cellSize)
    {
        this.piece = piece;
        this.movePoint = movePoint;
        this.cellSize = cellSize;
    }

    public bool Do()
    {
        return new BlinkMove(piece, movePoint, cellSize, Vector3.up, 2).Do()
               && new BlinkMove(piece, movePoint, cellSize, Vector3.right, 1).Do();
    }

    public bool Undo()
    {
        return new BlinkMove(piece, movePoint, cellSize, Vector3.down, 2).Do()
               && new BlinkMove(piece, movePoint, cellSize, Vector3.left, 1).Do();
    }
}
