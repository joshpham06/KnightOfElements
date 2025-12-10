using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip wolfAttack; 
    public AudioClip golemAttack; 
    public AudioClip tentacleHeadAttack; 
    public AudioClip fireAttack; 
    public AudioClip lightningAttack; 
    public AudioClip waterAttack; 
    public AudioClip earthAttack; 
    public AudioClip airAttack; 
    public AudioClip swordAttack; 
    private AudioSource audioSource;
    public static Sounds Instance;
    
    public void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
        
    }
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayGolemAttack()
    {
        audioSource.PlayOneShot(golemAttack);
    }
    
    public void PlayWolfAttack()
    {
        audioSource.PlayOneShot(wolfAttack);
    }
    
    public void PlayTentacleAttack()
    {
        audioSource.PlayOneShot(tentacleHeadAttack);
    }
    
    public void PlayFireAttack()
    {
        audioSource.PlayOneShot(fireAttack);
    }
    
    public void PlayLightningAttack()
    {
        audioSource.PlayOneShot(lightningAttack);
    }
    
    public void PlayEarthAttack()
    {
        audioSource.PlayOneShot(earthAttack);
    }
    
    public void PlayWaterAttack()
    {
        audioSource.PlayOneShot(waterAttack);
    }
    
    public void PlayAirAttack()
    {
        audioSource.PlayOneShot(airAttack);
    }
    
    public void PlaySwordAttack()
    {
        audioSource.PlayOneShot(swordAttack);
    }
    
}
