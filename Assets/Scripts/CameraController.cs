using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    public GameObject player, ground;
    private Vector3 offset;
    private Vector3 playerPosiion, cross, newPosition, vector;
    float length, cameraZ, angle;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        cameraZ = offset.z;
        length = (float) Math.Sqrt(Math.Pow(ground.transform.position.x - transform.position.x, 2) + Math.Pow(ground.transform.position.y - transform.position.y, 2));
        playerPosiion = new Vector3(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        vector = new Vector3(length * (player.transform.position.x - ground.transform.position.x) / Math.Abs(player.transform.position.x),
                             length * (player.transform.position.y - ground.transform.position.y) / Math.Abs(player.transform.position.y),
                             player.transform.position.z + cameraZ);

        transform.position = player.transform.position + offset;

        newPosition = new Vector3(player.transform.position.x, player.transform.position.y);
        angle = Vector3.Angle(playerPosiion, newPosition);
        cross = Vector3.Cross(playerPosiion, newPosition);
        if (cross.z < 0) angle = -angle;
        transform.rotation = Quaternion.Euler(28.7f, 0, angle);
    }
}
