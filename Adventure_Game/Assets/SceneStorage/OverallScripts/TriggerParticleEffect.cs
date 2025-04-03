using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int particleAmount = 10;
    public float minSpeed = 0.1f;
    public float maxSpeed = 1f;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            var main = particleSystem.main;
            main.startSpeed = Random.Range(minSpeed, maxSpeed);
            
            particleSystem.Emit(particleAmount);
        }
    }
}
