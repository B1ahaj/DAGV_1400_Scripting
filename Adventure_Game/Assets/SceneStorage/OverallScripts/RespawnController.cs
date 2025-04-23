using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
   public Transform startingPoint;
   public SimpleFloatData HealthData;
   public SimpleFloatData StaminaData;
   public SimpleIntData ScoreData;
   public float fullHealth = 1f;
   public float fullStamina = 1f;
   public int DeleteScore = 5;

   private void Update()
   {
      if (HealthData.value <= 0)
      {
         Respawn();
      }
   }

   private void Respawn()
   {
      CharacterController controller = GetComponent<CharacterController>();

      // Temporarily disable controller to move position
      controller.enabled = false;
      transform.position = startingPoint.position;
      transform.rotation = startingPoint.rotation;
      controller.enabled = true;
      
      // Stops movement so it does not carry over
      if (TryGetComponent<SimpleCharacterController>(out var simpleController))
      {
         simpleController.ResetVelocity();
      }

      // Resets the health and stamina
      HealthData.value = fullHealth;
      StaminaData.value = fullStamina;
      ScoreData.value -= DeleteScore;
   }
}
