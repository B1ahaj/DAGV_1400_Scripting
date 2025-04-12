using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public int firstParticleAmount = 10;
    public int secondParticleAmount = 20;
    public int thirdParticleAmount = 30;
    public float minTime = 0.1f;
    public float maxTime = 1f;
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
            StartCoroutine(EmitParticlesCoroutine());
            
            var main = particleSystem.main;
            main.startSpeed = Random.Range(minSpeed, maxSpeed);
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        particleSystem.Emit(firstParticleAmount);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        particleSystem.Emit(secondParticleAmount);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        
        particleSystem.Emit(thirdParticleAmount);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
    }
}
