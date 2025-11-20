using System;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameObject appleParticlePrefab;
    public AudioClip appleSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            var apple = other.GetComponent<Apple>();
            AppleManager.instance.CollectApple(apple.id);
            
            var appleParticleGO = Instantiate(appleParticlePrefab, other.transform.position, Quaternion.identity);
            var appleParticle = appleParticleGO.GetComponent<ParticleSystem>();
            appleParticle.Play();
            Destroy(appleParticleGO, appleParticle.main.duration);
            AudioManager.instance.PlaySfx(appleSound);
            UIManager.instance.SetAppleCount(AppleManager.instance.AppleCount());
            Destroy(other.gameObject);
        }
    }
}
