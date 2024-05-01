using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CatBehavior : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Animator Animator;
    public Rigidbody2D Rigidbody;
    // public AudioSource audioSource;
    public SpriteRenderer SpriteRenderer;
    private float _timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ResetAnimation()
    {
        Animator.SetBool("sit", false);
        Animator.SetBool("lick", false);
        Animator.SetBool("sleep", false);
        _timer = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        // audioSource.Play();
        _timer += Time.deltaTime;

        if (_timer > 8f && _timer < 15f)
            Animator.SetBool("sit", true);
        else if(_timer > 15f && _timer < 20f)
            Animator.SetBool("lick", true);
        else if(_timer > 20f && _timer < 23f)
            Animator.SetBool("lick", false);
        else if(_timer > 23f)
            Animator.SetBool("sleep", true);            

        //go right
        if (Input.GetKey(KeyCode.D))
        {
            //run
            if (Input.GetKey(KeyCode.LeftShift)){
                Animator.SetBool("run", true);
                ResetAnimation();
                Rigidbody.velocity = new Vector2(5f*Speed, Rigidbody.velocity.y);
            }else{
                SpriteRenderer.flipX = false;
                ResetAnimation();
                Rigidbody.velocity = new Vector2(Speed, Rigidbody.velocity.y);
            }
        }
        //go left
        else if (Input.GetKey(KeyCode.A))
        {
            //run
            if (Input.GetKey(KeyCode.LeftShift)){
                Animator.SetBool("run", true);
                ResetAnimation();
                Rigidbody.velocity = new Vector2(5f*-Speed, Rigidbody.velocity.y);
            }else{
                SpriteRenderer.flipX = true;
                ResetAnimation();
                Rigidbody.velocity = new Vector2(-Speed, Rigidbody.velocity.y);
            }
        }
        else
            Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
        //jump
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Rigidbody.AddForce(Vector2.up * JumpForce);
        // }
        //stop run
        if (Input.GetKeyUp(KeyCode.LeftShift))
            Animator.SetBool("run", false);

        if (Input.GetKey(KeyCode.S))
            Animator.SetBool("sit", true);
        //set speed
        Animator.SetFloat("velocityX", Mathf.Abs(Rigidbody.velocity.x));
    }
}