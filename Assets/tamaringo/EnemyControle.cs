using UnityEngine;

public class EnemyControle : MonoBehaviour
{
    public GameObject Target;
    public int life = 3;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger entro : " + collision.tag);
        if (collision.tag == "Bullet")
        {
            life--;
            if (life <= 0)
                Destroy(gameObject);
        }
    }
}
