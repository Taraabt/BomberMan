using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float bombTimer;
    IEnumerator LifetTime()
    {
        yield return new WaitForSeconds(bombTimer);

        Collider[] collider = Physics.OverlapBox(transform.position,Vector3.right);
        Collider[] collider2 = Physics.OverlapBox(transform.position, Vector3.forward);
        for (int i = 0; i < collider.Length; i++)
        {
            Debug.Log(collider[i].gameObject.layer);
            if (collider[i].gameObject.layer== 8)
            {
                Destroy(collider[i].gameObject);   
            }
        }
        for (int i = 0; i < collider2.Length; i++)
        {
            Debug.Log(collider2[i].gameObject.layer);
            if (collider2[i].gameObject.layer == 8)
            {
                Destroy(collider2[i].gameObject);
            }
        }
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        StartCoroutine(LifetTime());
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,Vector3.one);
    }
}
