using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Dummy
{
    [RequireComponent(typeof(DummyEnemyDamage))]
    public class DummyEnemyMovement : EnemyNavMeshWaypointMovement
    {
    }
}