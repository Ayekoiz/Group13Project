using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player_Controler : MonoBehaviour
{
    
    [SerializeField] float movespeed = 10f;
    float movederection = 0f;
    [SerializeField] float JumpV = 10f;
    bool jumpButtion = false;
    [SerializeField] float drag = .4f;
      [SerializeField] float Gravity = 10f;
    [SerializeField] Vector2 vilocity = Vector2.zero;
    bool OnGround = false;

    [SerializeField] float cooldown = 0;
    [SerializeField] float chargeCooldown = 1;
    [SerializeField] float chargehitTime =0.2f;
    bool charging = false;
    [SerializeField] float stabCoolfdown=0.25f;
    [SerializeField] float airslashCooldown = 0.25f;

    [SerializeField] GameObject ChargeEfect;
    [SerializeField] GameObject Chargeattack;
    [SerializeField] GameObject stab;
    [SerializeField] GameObject slash;
    [SerializeField] UI_Hud hud;
    [SerializeField] bool canSuper = false;
    int Health = 3;
    Rigidbody2D rb = null;
    SPUM_Prefabs animator = null;

    private AudioSource audioSource;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<SPUM_Prefabs>();
        animator.OverrideControllerInit();

        audioSource = GetComponent<AudioSource>();
        
    }

    //input
    public void Update()
    {
        hud.healthchange (Health);
        cooldown -= Time.deltaTime;
        //get input
        float tempmovederection = Input.GetAxis("Horizontal");
        if (tempmovederection > 0.03 || tempmovederection < -0.03 ) movederection = tempmovederection;
        jumpButtion = 0.4 < Input.GetAxis("Jump");
        bool attack1 = 0.4 < Input.GetAxis("Fire1");
        bool attack2 = (0.4 < Input.GetAxis("Fire2"))&& canSuper;
        transform.localScale = new Vector3(-Mathf.Sign(movederection), 1, 1);
        // animator and attacks
        if (charging && cooldown<= chargehitTime)
        {
            charging = false;
            ChargeEfect.SetActive(false);
            Chargeattack.SetActive(true);
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y + 0.4f), new Vector2(Mathf.Sign(movederection), 0),2f);
            for (int i = 0; i < hits.Length; i++) {
                
                BadGuyHealth badguy = hits[i].collider.gameObject.GetComponent<BadGuyHealth>();
                if (badguy != null) {
                    score( badguy.takeDamige(PlayerAtatckType.magic));
                }
            }
            //attack with charge
        }
        if (cooldown < 0) { 
            if (attack2)
            {
                //Start chageing
                cooldown = chargeCooldown;
                charging = true;
                ChargeEfect.SetActive(true);
                animator.PlayAnimation(PlayerState.ATTACK, 5);
                audioSource.Play();
            }
            else if (attack1)
            {
                if (OnGround)
                {
                    //stab
                    cooldown = stabCoolfdown;
                    stab.SetActive(true);
                    RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y + 0.4f), new Vector2(Mathf.Sign(movederection), 0), 0.5f);
                    for (int i = 0; i < hits.Length; i++)
                    {
                        
                        BadGuyHealth badguy = hits[i].collider.gameObject.GetComponent<BadGuyHealth>();
                        if (badguy != null)
                        {
                            score(badguy.takeDamige(PlayerAtatckType.Stab));
                        }
                    }
                    animator.PlayAnimation(PlayerState.ATTACK, 4);
                    audioSource.Play();
                }
                else
                {
                    //airslash
                    cooldown = airslashCooldown;
                    RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y + 0.4f), new Vector2(Mathf.Sign(movederection), 0), 1f);
                    for (int i = 0; i < hits.Length; i++)
                    {
                        BadGuyHealth badguy = hits[i].collider.gameObject.GetComponent<BadGuyHealth>();
                        if (badguy != null)
                        {
                            score(badguy.takeDamige(PlayerAtatckType.AirSlash));
                        }
                    }
                    slash.SetActive(true);
                    animator.PlayAnimation(PlayerState.ATTACK, 1);
                    audioSource.Play();
                }
            }
            else
            {
                ChargeEfect.SetActive(false);
                Chargeattack.SetActive(false);
                stab.SetActive(false);
                slash.SetActive(false);
                if (Mathf.Abs(movederection)>0.4)
                {
                    animator.PlayAnimation(PlayerState.MOVE, 0);
                }
                else
                {
                    animator.PlayAnimation(PlayerState.IDLE, 0);
                }
            }
        }
    }
    
    //phisics
    public void FixedUpdate()
    {
        if (Mathf.Abs(vilocity.x)> drag)
        vilocity.x -= drag* Mathf.Sign(vilocity.x);
        else
        vilocity.x = 0f;


        OnGround = Physics2D.Raycast(transform.position, -Vector2.up, 0.01F);
        vilocity.x = Mathf.Max(Mathf.Abs(vilocity.x), Mathf.Abs(movederection * movespeed)) *Mathf.Sign(movederection);
        if (!OnGround)
            vilocity.y -= Gravity * Time.deltaTime;
        else if (jumpButtion)
        {
            OnGround = false;
            vilocity.y = JumpV;
        } 
        else
            vilocity.y = 0f;

        rb.velocity = vilocity;
    }
    public void hurt(Vector2 pos)
    {
        Debug.Log("oucch");
        Health--;
        hud.healthchange(Health);
        vilocity = new Vector2(pos.x-transform.position.x, pos.y- transform.position.y);
        if (Health <= 0)
        {
            hud.GameOver();
        }
    }
    public void bounce()
    {
        vilocity.y = 10;
    }
    public void score(bool shouldscore)
    {
        if (!shouldscore) return;
        hud.addScore(1);
    }
}
