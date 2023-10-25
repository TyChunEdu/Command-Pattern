using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    private float cellSize;

    private List<Command> list;

    private int index;

    [SerializeField] private Transform movePoint;
    
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cellSize = 3.2f;
        list = new List<Command>();
        index = 0;
        movePoint.parent = null;
        moveSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            movePoint.position, 
            moveSpeed * Time.deltaTime);
    }

    public void Up()
    {
        Execute(new RealMove(transform, movePoint, cellSize, Vector3.up, 1));
    }
    
    public void Down()
    {
        Execute(new RealMove(transform, movePoint, cellSize, Vector3.down, 1));
    }
    
    public void Left()
    {
        Execute(new RealMove(transform, movePoint, cellSize, Vector3.left, 1));
    }
    
    public void Right()
    {
        Execute(new RealMove(transform, movePoint, cellSize, Vector3.right, 1));
    }

    public void Jump()
    {
        Execute(new JumpMove(transform, movePoint, cellSize));
    }

    public void Execute(Command c)
    {
        if (c.Do())
        {
            if (index < list.Count)
            {
                list.RemoveRange(index, list.Count - index);
            }

            list.Add(c);
            index++;
        }
    }

    public void Undo()
    {
        if (list.Count <= 0)
        {
            return;
        }
        if (index > 0)
        {
            if (list[index - 1].Undo())
            {
                index--;
            }
        }
    }

    public void Redo()
    {
        if (list.Count <= 0)
        {
            return;
        }
        if (index < list.Count)
        {
            index++;

            if (!list[index - 1].Do())
            {
                index--;
            }
        }
    }
}
