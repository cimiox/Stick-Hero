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
    private const float SIZE_IN_PIXELS = 50;
    private const float MINIMUM_SCALE = 1;
    private const float MAXIMUM_SCALE = 5;

    private Collider2D Collider { get; set; }
    public float SpaceBetweenPlatforms { get; set; }


    public float Size
    {
        get { return transform.localScale.x * SIZE_IN_PIXELS; }
    }


    private void OnEnable()
    {
        Collider = GetComponent<Collider2D>();
        Collider.enabled = false;

        transform.localScale = new Vector2(
            UnityEngine.Random.Range(MINIMUM_SCALE, MAXIMUM_SCALE),
            transform.localScale.y);

        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }

    private void TouchHandler_OnTouchUp()
    {
        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;

        //TODO: Write logic for enabled collider and check distance
    }
}
