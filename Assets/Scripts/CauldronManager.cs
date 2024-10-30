using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CauldronManager : MonoBehaviour
{

    [SerializeField]
    private CollectableManager collectableManager;
    [SerializeField]
    private ParticleSystem particleSystemPrefab;

    private Animator animator;
    private AudioSource audioSource;
    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            if (collectableManager != null)
            {
                collectableManager.collectItem();
            }
            

            Destroy(other.gameObject);

            animator.SetTrigger("Active");
            audioSource.Play();
            ActivateParticles();
        }    

    }

    private void ActivateParticles()
    {
        if (particleSystemPrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0f, 0.3f, 0f);
            ParticleSystem ps = Instantiate(particleSystemPrefab, spawnPosition, Quaternion.Euler(-90f, 0f, 0f)).GetComponent<ParticleSystem>();
            ps.Play();
            Destroy(ps.gameObject, 4f);
        }

    }
}
