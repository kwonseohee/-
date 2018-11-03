using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : PlayerFSMstate
{
    public Transform Marker;
    public float moveSpeed = 3.0f;

	// Use this for initialization
	void Start () {
        Marker = GameObject.FindGameObjectWithTag("Marker").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position,
        Marker.position,
        moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position,Marker.position) < 0.01f)
        { GetComponent<FSMManager>().SetState(playerState.IDLE); }

	}
}
