using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject Camera;
    private Vector3 dist;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position);
        Vector3 dir = (player.transform.position - enemy.transform.position).normalized;

        Camera.transform.position = enemy.transform.position + dir * dist;
        Camera.transform.rotation = Quaternion.LookRotation(-dir);
    }
}
