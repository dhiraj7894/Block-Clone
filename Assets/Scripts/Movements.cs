using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public PlayerManager playerManager;
    public float movementSpeed=5f;
    public float controlSpeed;

    public bool isTouching;
    float touchPosX;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 1, -44);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move)
        {
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            if (touchPosX <= -4.5f)
            {
                touchPosX = -4.5f;
            }
            if (touchPosX >= 4.5f)
            {
                touchPosX = 4.5f;
            }
        }
        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    
    }
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
