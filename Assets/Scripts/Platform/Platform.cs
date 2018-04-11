using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    /// <summary>
    /// Size for scale 1 in pixels
    /// </summary>
    private const float MINIMUM_SCALE = 1;
    private const float MAXIMUM_SCALE = 5;

    public const float CENTER_SIZE = 0.1f;

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

        transform.localScale = new Vector2(
            UnityEngine.Random.Range(MINIMUM_SCALE, MAXIMUM_SCALE),
            transform.localScale.y);

    }


    public void DisableCollider()
    {
        Collider.enabled = false;
    }
}
