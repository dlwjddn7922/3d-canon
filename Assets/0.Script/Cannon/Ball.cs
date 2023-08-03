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
    float flightDuration = 2f; // 시간 단위, 포물선이 목표에 도달하는데 걸리는 시간을 정의합니다.

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
            float yOffset = 4f; // Y 축에 대한 보정값, 조정하여 포물선의 높낮이를 조절할 수 있습니다.
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
            // 목표가 사라진 경우, 이동을 계속하기 위해 아래의 코드를 추가합니다.
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / flightDuration;
            Vector3 currentPos = Vector3.Lerp(initialPosition, targetPosition, percentageComplete);
            float yOffset = 4f; // Y 축에 대한 보정값, 조정하여 포물선의 높낮이를 조절할 수 있습니다.
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

        // 타겟의 머리 위치를 구하기 위해 Collider 정보를 이용합니다.
        Collider targetCollider = target.GetComponent<Collider>();
        if (targetCollider != null)
        {
            // 타겟의 머리 위치를 구합니다. 여기서는 적당한 Y축 오프셋을 사용합니다.
            float headOffset = 1.5f;
            targetPosition = targetCollider.bounds.center + Vector3.up * headOffset;
        }
        else
        {
            // 타겟에 Collider가 없는 경우, 기존 방식으로 목표 위치를 설정합니다.
            targetPosition = target.position + Vector3.up; //yOffset;
        }

        startTime = Time.time;
    }
}