using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);

            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookedRotation = Quaternion.LookRotation(new Vector3(
            direction.x, 0f, direction.z
            ));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookedRotation, Time.deltaTime * 50f);
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
