using Unity.VisualScripting;
using UnityEngine;







public class GameManager : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

 
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player" && collision.tag != "bullet")
            Destroy(gameObject);
    }
}
