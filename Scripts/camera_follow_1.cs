using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow_1 : MonoBehaviour
{
    private GameObject Player;
    private Vector3 PlayerPos;
    private Vector3 pos;

    void Start()
    {
        //Player Setup
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
    }

    void Update()
    {
        pos = this.transform.position;
        pos.x = Player.transform.position.x;
        pos.y = Player.transform.position.y;
        this.transform.position = pos;
    }
}
