using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public PlayerManager playerManager;
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerManager.levelState == PlayerManager.LevelState.NotFinished)
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPos.z);
        }
    }
   public void setCameraPos()
    {
        transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
    }
}
