using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]Canvas win;
    [SerializeField] Canvas lose;

    private void OnEnable()
    {
        Enemy.enemydie += EnemyCheck;
        Player.playerdie += PlayerDie;
        Bomb.playerdie += PlayerDie;
    }

    private void OnDisable()
    {
        Enemy.enemydie -= EnemyCheck;
        Player.playerdie -= PlayerDie;
        Bomb.playerdie -= PlayerDie;
    }

    private void PlayerDie()
    {
        Time.timeScale = 0;
        InputController.instance.input.Disable();
        lose.gameObject.SetActive(true);
    }

    private void EnemyCheck()
    {
        Enemy enemy = (Enemy)FindObjectOfType(typeof(Enemy));
        if (enemy == null) {
            Time.timeScale = 0;
            InputController.instance.input.Disable();
            win.gameObject.SetActive(true);
        }
    }
    

}
