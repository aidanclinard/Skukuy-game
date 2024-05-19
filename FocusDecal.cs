using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusDecal : MonoBehaviour
{

    public GameObject focusDecal;

    private float angle;

    private float size;

    public float rotspeed;

    public float sizespeed;

    public float startsize;

    public float alphaLevel = 0.5f;

    public float opacityrate;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left shift"))
        {
            focusDecal.transform.rotation = Quaternion.Euler(0,0,angle);
            focusDecal.transform.localScale = new Vector3(size, size, size);
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,alphaLevel);

            angle += rotspeed;
            if(size < 2)
            {
                size += sizespeed;
            }
            if(alphaLevel < 1)
            {
                alphaLevel += opacityrate;
            }
        }
        else
        {
            focusDecal.transform.eulerAngles = new Vector3(0,0,0);
            focusDecal.transform.localScale = new Vector3(startsize, startsize, startsize);
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);

            alphaLevel = 0f;
            size = startsize;
            angle = 0f;
        }
    }
}
