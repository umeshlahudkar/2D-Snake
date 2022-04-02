using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Respwan snake position on Y-axis if it is going out of Screen
/// </summary>
public class YaxisScreenWrapController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            Vector2 respwanPosition = collision.gameObject.transform.position;

            respwanPosition.x =  1f * Mathf.Round(respwanPosition.x);
            respwanPosition.y = -1f * Mathf.Round(respwanPosition.y);

            collision.gameObject.transform.position = respwanPosition;
        }
    }
}
