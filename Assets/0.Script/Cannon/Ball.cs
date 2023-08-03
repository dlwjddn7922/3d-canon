using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Ball : MonoBehaviour
{
    Transform target;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * 5f); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.GetMask("Ground") == 64)
        {
            if(target != null && target.GetComponent<Enemy>())
            {
                target.GetComponent<Enemy>().Hit(20);
            }
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        pos = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}*/
public class Ball : MonoBehaviour
{
    Transform target;
    Vector3 initialPosition;
    Vector3 targetPosition;
    float startTime;
    float flightDuration = 2f; // �ð� ����, �������� ��ǥ�� �����ϴµ� �ɸ��� �ð��� �����մϴ�.

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / flightDuration;

            Vector3 currentPos = Vector3.Lerp(initialPosition, targetPosition, percentageComplete);
            float yOffset = 4f; // Y �࿡ ���� ������, �����Ͽ� �������� �����̸� ������ �� �ֽ��ϴ�.
            currentPos.y += yOffset * (percentageComplete - percentageComplete * percentageComplete);

            transform.position = currentPos;

            if (percentageComplete >= 1.0f)
            {
                if (target.GetComponent<Enemy>())
                {
                    target.GetComponent<Enemy>().Hit(20);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            // ��ǥ�� ����� ���, �̵��� ����ϱ� ���� �Ʒ��� �ڵ带 �߰��մϴ�.
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / flightDuration;
            Vector3 currentPos = Vector3.Lerp(initialPosition, targetPosition, percentageComplete);
            float yOffset = 4f; // Y �࿡ ���� ������, �����Ͽ� �������� �����̸� ������ �� �ֽ��ϴ�.
            currentPos.y += yOffset * (percentageComplete - percentageComplete * percentageComplete);
            transform.position = currentPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        initialPosition = transform.position;

        // Ÿ���� �Ӹ� ��ġ�� ���ϱ� ���� Collider ������ �̿��մϴ�.
        Collider targetCollider = target.GetComponent<Collider>();
        if (targetCollider != null)
        {
            // Ÿ���� �Ӹ� ��ġ�� ���մϴ�. ���⼭�� ������ Y�� �������� ����մϴ�.
            float headOffset = 1.5f;
            targetPosition = targetCollider.bounds.center + Vector3.up * headOffset;
        }
        else
        {
            // Ÿ�ٿ� Collider�� ���� ���, ���� ������� ��ǥ ��ġ�� �����մϴ�.
            targetPosition = target.position + Vector3.up; //yOffset;
        }

        startTime = Time.time;
    }
}