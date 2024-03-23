using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] float creatureSpeed = 1f;
    bool active = true;
    private Vector2 targetPos;
    internal void Leave()
    {
        //disable chasing behaviour
        active = false;
        //go back to closest spawn point
        targetPos = CreatureSpawner.Instance.SpawnPoints.OrderBy(p => Vector2.Distance(p.position, transform.position)).First().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            targetPos = FindObjectOfType<PlayerController>().transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, creatureSpeed * Time.deltaTime);

        if (!active && Vector2.Distance(targetPos, transform.position) < 0.5f)
            Destroy(gameObject);
    }
}
