using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _speedAxel;

    [SerializeField] private List<Skill> skills;

    public Rigidbody2D Rb2D { get; protected set; }

    public sealed class SkillID
    {
        public const int SHIELD = 0;
        public const int DASH = 1;
        public const int MULTIPLE_JUMP = 2;
    }

    private void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnJump();
        OnDash();
        Interaction();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        var targetVelocity = _speed * moveX * Vector2.right;
        targetVelocity.y = Rb2D.velocity.y;
        Rb2D.AddForce(_speedAxel * Rb2D.mass * (targetVelocity - Rb2D.velocity));
    }

    private void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skills[SkillID.MULTIPLE_JUMP].CanUse(this))
            {
                skills[SkillID.MULTIPLE_JUMP].Use(this);
            }
        }
    }

    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skills[SkillID.SHIELD].CanUse(this))
            {
                skills[SkillID.SHIELD].Use(this);
            }
        }
    }

    private void OnDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (skills[SkillID.DASH].CanUse(this))
            {
                skills[SkillID.DASH].Use(this);
            }
        }
    }
}
