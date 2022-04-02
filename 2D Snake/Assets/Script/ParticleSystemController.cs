using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] ParticleSystem greenFood;
    [SerializeField] ParticleSystem redFood;
    [SerializeField] ParticleSystem dead;

    public void playGreenFoodParticleEffect()
    {
        greenFood.Play();
    }

    public void playRedFoodParticleEffect()
    {
        redFood.Play();
    }

    public void playDeadParticleEffect()
    {
        dead.Play();
    }
}

