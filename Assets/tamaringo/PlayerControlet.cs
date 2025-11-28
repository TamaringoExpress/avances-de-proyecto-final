            using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShootProjectile();
        }

        if (Input.GetMouseButtonDown(0))
        {
            MoveToDirection();
        }
    }

    public void MoveToDirection()
    {
        Vector2 worlPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 moveDirection = (worlPosition - (Vector2)transform.position).normalized;

        transform.position += moveDirection * Speed;
    }

    public void ShootProjectile()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worlPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 shootDirection = worlPosition - (Vector2)transform.position;
        Vector2 normalizeShootDirection = shootDirection.normalized;

        GameObject bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;

        bullet.transform.right = normalizeShootDirection;

       // print(mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "enemy")
        {
            print("PERDISTE");
        }
    }

 
}
