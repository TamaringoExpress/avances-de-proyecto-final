using UnityEngine;

public class Camaramoved : MonoBehaviour
{
    public GameObject Target;
    public float camareSeepd;
    public float camareRange;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    public void CamerMovementMechanic()
    {
        float distance = Vector2.Distance(Target.transform.position, transform.position);

        if (distance >= camareRange)
        {
            Vector3 target = Target.transform.position;
            target.z = -10;
            target.y = transform.position.y;

            Vector3 dir = (target - transform.position).normalized;

            transform.position += dir * camareSeepd * Time.deltaTime;
        }
    }
    void Update()
    {
        CamerMovementMechanic();
    }
}
