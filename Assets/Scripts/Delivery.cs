using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPicked;
    private SpriteRenderer sr;
    [SerializeField] private float destroyTime;
    [SerializeField] private Color32 hasPickedColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPickedColor = new Color32(255, 255, 255, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Cargo" && !hasPicked)
        {
            hasPicked = true;
            sr.color = hasPickedColor;
            Destroy(other.gameObject,destroyTime);
        }

        if (other.gameObject.tag == "Customer" && hasPicked)
        {
            hasPicked = false;
            Destroy(other.gameObject,destroyTime);
            sr.color = noPickedColor;
        }
    }
}
