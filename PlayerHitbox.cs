using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    [SerializeField] private GameObject player;

    public float alphaLevel = 0.5f;

    public float opacityrate;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 999);


        if(Input.GetKey("left shift"))
        {
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,alphaLevel);
            if(alphaLevel < 1)
            {
                alphaLevel += opacityrate;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);

            alphaLevel = 0f;
        }
    }
}
