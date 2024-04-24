using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]Canvas canvas;
    Input input;
    private void OnEnable()
    {
        input=new Input();
        Enemy.enemydie += EnemyCheck;
    }

    private void OnDisable()
    {
        Enemy.enemydie += EnemyCheck;
    }

    private void EnemyCheck()
    {
        Enemy enemy = (Enemy)FindObjectOfType(typeof(Enemy));
        if (enemy == null) {
            InputController.instance.input.Disable();
            canvas.gameObject.SetActive(true);
        }
    }

}
