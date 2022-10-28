using Mirror;
using UnityEngine;

public class player2behaviour : NetworkBehaviour
{
    public float speed = 10.0f;
    private float borderY = 4.4f; //8.3
    private float borderX1 = 0.8f; private float borderX2 = 8.5f;

    void Update()
    {
        if (hasAuthority && isClient)
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.UpArrow) && pos.y <= borderY)
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) && pos.y >= -borderY)
            {
                pos.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow) && pos.x <= borderX2)
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && pos.x >= borderX1)
            {
                pos.x -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
    }

}
