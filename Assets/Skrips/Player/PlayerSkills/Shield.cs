using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill
{
    [Header("GameObject")]
    [SerializeField] protected GameObject projectilePrefab;

    [Header("Settinge")]
    [SerializeField] protected float shootForce = 10f;
    [SerializeField] private float duration;

    protected GameObject projectile;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (projectile == null) return;

        MoveShield();
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        projectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
        Destroy(projectile, duration);
    }

    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player) && projectile == null;
    }

    private void MoveShield()
    {
        var mousePos = Input.mousePosition;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        projectile.transform.position = transform.position;

        Vector3 direction = mousePos - transform.position;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
