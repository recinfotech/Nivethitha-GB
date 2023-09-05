using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Health : MonoBehaviour


{

    //private Component[] components;

    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] public GameObject failedPopUp;
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

   
    private void Awake()
    {

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        Debug.Log("WholeScript");
    }

    private void Update()
    {


    }
    public void TakeDamage(float _damage)
    {
       Debug.Log("hi");
        //currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
    //    
        if (currentHealth > 0)
        {
            
            anim.SetTrigger("Hurt");
           Debug.Log(currentHealth);
            StartCoroutine(Invulnerability());
            //   SoundManager.instance.PlaySound(hurtSound);

        }
        else
        {
            if (!dead)
            {
               
                anim.SetTrigger("die");
                failedPopUp.SetActive(true);
                FindObjectOfType<StarHandlerPopFailed>().starsAchieved();
                anim.SetTrigger("SquareBlast");
                failedPopUp.SetActive(false);
                anim.SetTrigger("Blast");
                failedPopUp.SetActive(false);

                if (GetComponent<PlayerMovement>() != null)
                {
                    GetComponent<PlayerMovement>().enabled = false;
                }

                //Enemy
                if (GetComponent<EnemyFollow>() != null)
                {
                    GetComponent<EnemyFollow>().enabled = false;
                }
                if (GetComponent<EnemySideWays>() != null)
                {
                    GetComponent<EnemySideWays>().enabled = false;
                }
                dead = true;
                //  SoundManager.instance.PlaySound(deathSound);
            }
        }


    }

    //public void Respawn()
    //{
    //    dead = false;
    //    anim.ResetTrigger("Circle");

    //    anim.Play("Idle");
    //    StartCoroutine(Invulnerability());
    //    anim.SetBool("CircleRun", true);
    //}
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

   
  
    //public void OpponentRespawn()
    //{

    //    Debug.Log("OppResp");
    //    if (anim.GetBool("SquareBlast") == true)//&& TriggerStateTransition )
    //    {
    //        anim.Play("anim_07", 0);
    //        GetComponent<PlayerMovement>().gameObject.SetActive(true);
    //        anim.SetBool("Run", true);
    //    }
    //    if (anim.GetBool("Blast") == true)
    //    {
    //        GetComponent<PlayerMovement>().gameObject.SetActive(true);
    //        anim.SetBool("Run", true);
    //    }
    //    if (anim.GetBool("die") == true)
    //    {
    //        // GetComponent<EnemyFollow>().gameObject.SetActive(true);
    //    }
    //}


}