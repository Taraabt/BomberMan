using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float bombTimer;
    IEnumerator LifetTime()
    {
        Player.instance.spawnBomb = true;
        yield return new WaitForSeconds(bombTimer);

        Collider[] collider = Physics.OverlapBox(transform.position,Vector3.right);
        Collider[] collider2 = Physics.OverlapBox(transform.position, Vector3.forward);
        for (int i = 0; i < collider.Length; i++)
        {
            LayerMask layer = collider[i].gameObject.layer;
            Debug.Log(collider[i].gameObject.layer);
            if (layer>7)
            {
                Destroy(collider[i].gameObject);   
            }
        }
        for (int i = 0; i < collider2.Length; i++)
        {
            LayerMask layer = collider2[i].gameObject.layer;
            Debug.Log(collider2[i].gameObject.layer);
            if (layer>7)
            {
                Destroy(collider2[i].gameObject);
            }
        }
        Player.instance.spawnBomb = false;
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        StartCoroutine(LifetTime());
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.green;
       Gizmos.DrawWireCube(transform.position,Vector3.right);
       Gizmos.DrawWireCube(transform.position, Vector3.forward);
    }
}
