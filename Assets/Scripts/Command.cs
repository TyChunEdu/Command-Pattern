using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    bool Do();

    bool Undo();
}
