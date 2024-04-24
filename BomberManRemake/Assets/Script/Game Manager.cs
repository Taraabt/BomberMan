using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void OnEnable()
    {
        Enemy.enemydie += EnemyCheck;
    }

    private void EnemyCheck()
    {
               
    }

    private void OnDisable()
    {
        Enemy.enemydie += EnemyCheck;
    }
}
