﻿using UnityEngine;
using System.Collections;

public class EnemyS29 : MonoBehaviour {

    public Transform player;
    static Animator S29;
    // Use this for initialization
    void Start()
    {

        S29 = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(player.position, this.transform.position) < 12)
        {
            Vector3 direction = player.position - this.transform.position;
            //float angle = Vector3.Angle(direction, this.transform.forward);
            // if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
            // {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            S29.SetBool("isIdle", false);
            if (direction.magnitude > 3)
            {
                this.transform.Translate(0, 0, 0.2f);
                S29.SetBool("isRunning", true);
                S29.SetBool("isAttacking", false);
            }
            else
            {
                S29.SetBool("isAttacking", true);
                S29.SetBool("isRunning", false);
            }
        }

        else
        {
            S29.SetBool("isIdle", true);
            S29.SetBool("isRunning", false);
            S29.SetBool("isAttacking", false);
        }

    }
}
