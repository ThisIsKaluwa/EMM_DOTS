using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            return;
        }
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            return;
        }
        
        transform.rotation = player.transform.rotation;
        transform.position = player.transform.position + player.transform.rotation * offset;
    }
}
