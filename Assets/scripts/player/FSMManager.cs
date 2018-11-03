using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK
}

public class FSMManager : MonoBehaviour {

    public playerState currentState;
    public playerState startState;
    public Transform Marker;

    Dictionary<playerState, PlayerFSMstate> states
        = new Dictionary<playerState, PlayerFSMstate>();

    private void Awake()
    {
        Marker = GameObject.FindGameObjectWithTag("Marker").transform;
        states.Add(playerState.IDLE, GetComponent<PlayerIDLE>());
        states.Add(playerState.RUN, GetComponent<PlayerRUN>());
        states.Add(playerState.CHASE, GetComponent<PlayerCHASE>());
        states.Add(playerState.ATTACK, GetComponent<PlayerATTACK>());

        states[startState].enabled = true;

    }

    public void SetState(playerState newState)
    {
        foreach(PlayerFSMstate fsm in states.Values)
        {
            fsm.enabled = false;
        }

        states[newState].enabled = true;
    }

    // Use this for initialization
    void Start () {
        SetState(startState);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 1000))
            {
               Marker.position = hit.point;

                SetState(playerState.RUN);
            }
        }
	}
}
