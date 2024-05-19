using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;



    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 999);
    }
}
