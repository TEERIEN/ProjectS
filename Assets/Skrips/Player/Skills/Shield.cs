using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill
{
    [Header("GameObject")]
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected GameObject _spherePrefab;

    [Header("Settinge")]
    [SerializeField] protected float shootForce = 10f;
    [SerializeField] private float duration;

    [SerializeField] private float _distance;

    protected GameObject shieldProjectile;
    protected GameObject sphereProjectile;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (shieldProjectile == null) return;

        MoveShield();
    }
    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player);
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        if (shieldProjectile)
        {
            var mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            var direction = (mousePos - shieldProjectile.transform.position).normalized;
            sphereProjectile = Instantiate(_spherePrefab, shieldProjectile.transform.position + direction * _distance, Quaternion.identity);

            Rigidbody2D rb = shieldProjectile.GetComponent<Rigidbody2D>();

            rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
            Destroy(sphereProjectile, duration);
        }
        else
        {
            shieldProjectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
            Destroy(shieldProjectile, duration);
        } 
    }


    private void MoveShield()
    {
        var mousePos = Input.mousePosition;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        shieldProjectile.transform.position = transform.position;

        Vector3 direction = mousePos - transform.position;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shieldProjectile.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
