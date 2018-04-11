﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    public const float CENTER_SIZE = 0.5f;

    private Collider2D Collider { get; set; }
    public float SpaceBetweenPlatforms { get; set; }


    public float Size
    {
        get { return transform.lossyScale.x / 2; }
    }

    public float Center
    {
        get { return transform.position.x + (EndPosition.x - transform.position.x) / 2; }
    }

    public Vector2 EndPosition
    {
        get
        {
            return new Vector2(
          transform.position.x + Size,
          transform.position.y);
        }
    }


    private void OnEnable()
    {
        Collider = GetComponent<Collider2D>();

        

    }


    public void DisableCollider()
    {
        Collider.enabled = false;
    }
}
