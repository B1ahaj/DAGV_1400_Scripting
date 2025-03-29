using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Util/Removal Util V2")]
public class RemoverV2 : ScriptableObject
{
    public void Destroyer(GameObject gameObject)
    {
        MonoBehaviour monoBehaviour = gameObject.GetComponent<MonoBehaviour>();
        if (monoBehaviour != null)
        {
            monoBehaviour.StartCoroutine(DestroyAfterEffects(gameObject));
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterEffects(GameObject gameObject)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        Animator animator = gameObject.GetComponent<Animator>();

        float audioDuration = audioSource != null && audioSource.isPlaying ? audioSource.clip.length - audioSource.time : 0f;
        float animationDuration = animator != null && animator.GetCurrentAnimatorStateInfo(0).length > 0 ? animator.GetCurrentAnimatorStateInfo(0).length : 0f;

        float delay = Mathf.Max(audioDuration, animationDuration);
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }

        Object.Destroy(gameObject);
    }
}

