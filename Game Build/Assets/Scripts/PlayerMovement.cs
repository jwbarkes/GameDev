using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public CharacterController cont;
    public float normalSpeed = 2;
    public float sprintSpeed = 5;
    private float speed;
    private Vector3 dir = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)) speed = sprintSpeed;
        else speed = normalSpeed;

        if(Input.GetKey(KeyCode.W)){
            dir = player.transform.forward;
            transform.Translate(dir*speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            dir = -player.transform.right;
            transform.Translate(dir*speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            dir = -player.transform.forward;
            transform.Translate(dir*speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            dir = player.transform.right;
            transform.Translate(dir*speed*Time.deltaTime);
        }
    }
}
