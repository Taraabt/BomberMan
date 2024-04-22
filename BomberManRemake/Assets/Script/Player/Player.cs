using UnityEngine;

public class Player : MonoBehaviour
{
    public bool checkObject = false;
    public static Player instance;
    [SerializeField]LayerMask layer;

    private void Start()
    {
        if (instance == null)
        instance = this;
    }

    public void CheckMove(Vector2 pos)
    {
        if(pos.x==0&& pos.y==1)
        {
            checkObject=Physics.Raycast(transform.position,Vector3.forward, 1f, layer);
        }else if(pos.x == 0 && pos.y == -1)
        {
            checkObject = Physics.Raycast(transform.position, Vector3.back, 1f, layer);
        }else if (pos.x == 1 && pos.y == 0)
        {
            checkObject = Physics.Raycast(transform.position, Vector3.right, 1f, layer);
        }else if (pos.x == -1 && pos.y == 0)
        {
            checkObject = Physics.Raycast(transform.position, Vector3.left, 1f, layer);
        }
        else if(Mathf.Abs(pos.x)==1&&Mathf.Abs(pos.y)==1)
        {
            checkObject = true;
        }else
        {
            checkObject= false;
        }
    }

}
