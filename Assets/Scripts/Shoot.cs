using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform shootPoint;      // Punto desde donde dispara
    public float bulletSpeed = 10f;   // Velocidad de la bala

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        float direction = transform.localScale.x > 0 ? 1f : -1f;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * bulletSpeed, 0f);
    }
}

