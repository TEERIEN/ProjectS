using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour, IGroundCheck
{
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _distanceLazer;

    private void Update()
    {
        IsGround();
    }

    public bool IsGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _distanceLazer, _groundLayer);

        Debug.DrawRay(transform.position, Vector2.down * _distanceLazer, Color.red);

        if (hit.transform != null) return true;

        return false;
    }
}
