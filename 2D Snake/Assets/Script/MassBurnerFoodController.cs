using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBurnerFoodController : MonoBehaviour
{
    [SerializeField] BoxCollider2D Boundry;
    [SerializeField] GameObject MassBurnerFood;
    Bounds bounds;

    List<GameObject> instantiateBurnerFood;

    float minWaitTime = 10f;
    float maxWaitTime = 30f;

    bool isInstantiateFood = false;
    float instantiateFoodTime = 0f;
    float destroyFoodTime = 8f;

    private void Start()
    {
        StartCoroutine(InstantiateMassBurnerFood());

        instantiateBurnerFood = new List<GameObject>();

    }

    private void Update()
    {
        if (isInstantiateFood)
        {
            instantiateFoodTime += Time.deltaTime;
            if (instantiateFoodTime >= destroyFoodTime)
            {
                DestroyMassBurnerFood();
            }
        }
    }

    IEnumerator InstantiateMassBurnerFood()
    {
        float waitTime = Random.Range(minWaitTime, maxWaitTime);

        yield return new WaitForSeconds(waitTime);

        if (SnakeController.currentBodySefmentsCount >= SnakeController.minBodySefmentsCount ||
            Player2Controller.currentBodySefmentsCount >= Player2Controller.minBodySefmentsCount)
        {
            bounds = Boundry.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            GameObject massBurnerFood = Instantiate(MassBurnerFood, new Vector2(x, y), Quaternion.identity);
            instantiateBurnerFood.Add(massBurnerFood);
            isInstantiateFood = true;

        }

        StartCoroutine(InstantiateMassBurnerFood());

    }

    public void DestroyMassBurnerFood()
    {
        Destroy(instantiateBurnerFood[instantiateBurnerFood.Count - 1]);
        instantiateBurnerFood.RemoveAt(instantiateBurnerFood.Count - 1);

        isInstantiateFood = false;
        instantiateFoodTime = 0f;
    }
}
