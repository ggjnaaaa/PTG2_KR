using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//~~~~~~    ������ �������    ~~~~~~//
public class Smilr : MonoBehaviour
{
    public GameObject target;  // ������ �� ����
    public Text counter;  // ������ �� �������

    NavMeshAgent agent;
    Animator animator;

    float attack_distance;  // ��������� �� ������� ���������� �������� �����

    void Start()
    {
        attack_distance = 5;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.SetDestination(target.transform.position);
        agent.stoppingDistance = attack_distance;
    }

    //~~~~~~    ������ �������� ����� �� �������� ���������    ~~~~~~//
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= attack_distance)
            animator.SetBool("attack", true);
    }

    //~~~~~~    ������ �������� ��������� ����� � ������    ~~~~~~//
    public void Death()
    {
        animator.SetBool("hit", true);
        agent.SetDestination(transform.position);

        counter.text = Convert.ToString(Convert.ToInt32(counter.text) + 1);
    }

    //~~~~~~    �������� �� �����    ~~~~~~//
    public void Die() => Destroy(this.gameObject);
}
