using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Awake()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Round(pos.x), 1, Mathf.Round(pos.z));
    }

}
