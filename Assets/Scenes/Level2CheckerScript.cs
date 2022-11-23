using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CheckerScript : LevelCheckerScript
{
    // fields & methods to test against loading next scene...
    public override bool CanEnterNextLevel()
    {
        return true;
    }
}
