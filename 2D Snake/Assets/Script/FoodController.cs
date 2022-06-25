using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainerFoodController : MonoBehaviour
{
    [SerializeField] BoxCollider2D Boundry;
    Bounds bounds;
    private void Start()
    {
        RandomMassGainerFoodPosition();
    }

  
    public void RandomMassGainerFoodPosition()
    {
        bounds = Boundry.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        gameObject.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<SnakeController>() != null
            || collision.gameObject.GetComponent<Player2Controller>() != null)
        {
            RandomMassGainerFoodPosition();
        }
    }


}
