using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Transform target;
    public int Power { get; set; }
    float shootAngle1 = 50f; // 발사 각도 (0~90도)
    float gravity1 = -9.81f; // 중력 가속도
    
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.GetMask("Ground") == 64)
        {
            if (target != null && target.GetComponent<Enemy>())
            {
                target.GetComponent<Enemy>().Hit(Power);

            }
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        Shoot(new Vector3(target.position.x, target.position.y,target.position.z));
    }
    private void Shoot(Vector3 pos)
    {
        // 발사 힘
        float shootForce = Vector3.Distance(transform.position, pos) * 2.5f;

        float radianAngle = Mathf.Deg2Rad * shootAngle1;
        float totalFlightTime = (2f * shootForce * Mathf.Sin(radianAngle)) / -gravity1;

        Vector3 targetPosition = new Vector3(pos.x, pos.y, pos.z); ;
        Vector3 direction = (targetPosition - transform.position).normalized;

        float horizontalSpeed = shootForce * Mathf.Cos(radianAngle);
        float verticalSpeed = Mathf.Sqrt(-2f * gravity1 * transform.position.y);

        Vector3 horizontalVelocity = direction * horizontalSpeed;
        Vector3 verticalVelocity = Vector3.up * verticalSpeed;

        rb.velocity = horizontalVelocity + verticalVelocity;

        Destroy(gameObject, totalFlightTime);
    }
}
