using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleJump : Skill
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpsNumber;
    public int _jumpCounter;

    [SerializeField] private float _coyoteTime;
    public float _coyoteTimer;

    private PlayerGroundChecker _groundChecker;

    private void Start()
    {
        _groundChecker = GetComponent<PlayerGroundChecker>();
    }

    private void Update()
    {
        RemainingTimeForJump();
    }

    public override bool CanUse(PlayerController player)
    {
        if (_coyoteTimer> 0)
        {
            return base.CanUse(player);
        }
        else
        {
            if (_jumpCounter > 0)
            {
                return base.CanUse(player);
            }
        }

        return false;
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        player.Rb2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        _jumpCounter--;
    }

    public void RemainingTimeForJump()
    {
        if (_groundChecker.IsGround())
        {
            _coyoteTimer = _coyoteTime;
            _jumpCounter = _jumpsNumber;
        }
        else
        {
            _coyoteTimer -= Time.deltaTime;
        }
    }
}
