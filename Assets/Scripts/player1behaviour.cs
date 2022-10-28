using Mirror;
using UnityEngine;

public class player1behaviour : NetworkBehaviour // Сетевой объект
{
    public float speed = 10.0f;
    private float borderY = 4.4f; //8.3
    private float borderX1 = -8.5f; private float borderX2 = -0.8f;

    void FixedUpdate()
    {
        if (isLocalPlayer) // Есть ли права изменять объект
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w") && pos.y <= borderY)
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s") && pos.y >= -borderY)
            {
                pos.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey("a") && pos.x >= borderX1)
            {
                pos.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d") && pos.x <= borderX2)
            {
                pos.x += speed * Time.deltaTime;
            }
            transform.position = pos;
        }
    }

}
