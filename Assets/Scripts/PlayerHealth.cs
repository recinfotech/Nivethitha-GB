/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRend;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private bool someBool = false;
    private float timer;
    private float interval;

    private void Awake()
    {

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        // Debug.Log("WholeScript");
    }

    private void Update()
    {


    }
    public void TakeDamage(float _damage)
    {
        Debug.Log("hi");
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            Debug.Log(currentHealth);
            Debug.Log("hurt");
            anim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
            //   SoundManager.instance.PlaySound(hurtSound);

        }
        else
        {
            if (!dead)
            {
                // anim.SetBool("CircleRun", true);
                anim.SetTrigger("die");
              

                if (GetComponent<PlayerMovement>() != null)
                {
                    GetComponent<PlayerMovement>().enabled = false;
                }
                
                //Enemy
                //if (GetComponent<EnemyFollow>() != null)
                //{
                //    GetComponent<EnemyFollow>().enabled = false;
                //}
                //if (GetComponent<EnemySideWays>() != null)
                //{
                //    GetComponent<EnemySideWays>().enabled = false;
                //}
                //dead = true;
                //  SoundManager.instance.PlaySound(deathSound);
            }
        }


    }
    //public void AddHealth(float _value)
    //{
    //    currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    //}
    public void Respawn()
    {
        dead = false;
      //  AddHealth(startingHealth);
        anim.ResetTrigger("die");

        anim.Play("idle");
        StartCoroutine(Invulnerability());
        // ACTIVATE ALL ATTACHED COMPONENT CLASSES
        //foreach (Behaviour component in components) //
        // component.enabled = true;              //
        anim.SetBool("grounded", true);
    }
    public IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        //InvunerabilityDuration
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

}*/
