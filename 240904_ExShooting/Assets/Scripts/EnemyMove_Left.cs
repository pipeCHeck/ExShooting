using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Left : EnemyMove
{
    protected override void Move()
    {
        base.Move();
        ObjectMove(Vector3.left, GetMoveSpeed());
    }
}
