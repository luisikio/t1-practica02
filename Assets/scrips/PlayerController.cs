using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10;
    public float Jumpforce = 5;

    private bool choque = false;
    private int aumentarcelocidad = 0;
    private int muertes = 0;
    



    // Start is called before the first frame update
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    private Animator _animator;

    
    private static readonly int run=0;
    private static readonly int jump = 2;
    private static readonly int slide = 1;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(velocity, _rigidbody2D.velocity.y);
        changeAnimation(run);
        if (muertes==10)
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            changeAnimation(jump);
            _rigidbody2D.AddForce(Vector2.up*Jumpforce,ForceMode2D.Impulse);
            muertes += 1;

        }

        if (Input.GetKey(KeyCode.C))
        {
            changeAnimation(slide);
            

        }
        
    }

    private void changeAnimation(int animation)
    {
        _animator.SetInteger("Estado",animation);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        var tag = other.gameObject.tag;
        if (tag=="enemy")
        {
            choque = true;
            aumentarcelocidad += 1;
            muertes += 1;
            if (Input.GetKey(KeyCode.C))
            {
                Destroy(other.gameObject);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag=="enemy")
        {
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
