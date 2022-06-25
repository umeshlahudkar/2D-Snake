using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] BoxCollider2D Boundry;

    private void Start()
    {
        RandomMassGainerFoodPosition();
    }
    public void RandomMassGainerFoodPosition()
    {
        Bounds bounds = Boundry.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        gameObject.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<SnakeController>() != null)
        {
            RandomMassGainerFoodPosition();
        }
    }
}
