using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocity = 10;
    // Start is called before the first frame update
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.flipX = true;
        _rigidbody2D.velocity = new Vector2(velocity*-1, _rigidbody2D.velocity.y);
    }
}
