using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDelegate();
    public static event EnemyDelegate enemydie;
    bool timer=true;
    bool canMove;
    [SerializeField] float waitTime;
    Vector3[] position= { Vector3.forward,Vector3.back,Vector3.right,Vector3.left};
    [SerializeField]LayerMask layer;


    IEnumerator Move()
    {
        timer = false;
        yield return new WaitForSeconds(waitTime);
        int rand = Random.Range(0, 4);
        canMove=Physics.Raycast(transform.position,position[rand],1f,layer); 
        while (canMove){ 
            rand= Random.Range(0, 4);
            canMove = Physics.Raycast(transform.position, position[rand], 1f, layer);
        }
        transform.position+=position[rand];
        

        timer = true;
    }
    private void FixedUpdate()
    {
        if (timer)
            StartCoroutine(Move());
    }
    private void OnDestroy()
    {
        enemydie(); 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, position[0]);
    }

}
