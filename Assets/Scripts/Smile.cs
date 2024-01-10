using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//~~~~~~    Скрипт монстра    ~~~~~~//
public class Smilr : MonoBehaviour
{
    public GameObject target;  // Ссылка на цель
    public Text counter;  // Ссылка на счётчик

    NavMeshAgent agent;
    Animator animator;

    float attack_distance;  // Дистанция на которой начинается анимация атаки

    void Start()
    {
        attack_distance = 5;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.SetDestination(target.transform.position);
        agent.stoppingDistance = attack_distance;
    }

    //~~~~~~    Запуск анимации удара на заданной дистанции    ~~~~~~//
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= attack_distance)
            animator.SetBool("attack", true);
    }

    //~~~~~~    Запуск анимации получения удара и смерти    ~~~~~~//
    public void Death()
    {
        animator.SetBool("hit", true);
        agent.SetDestination(transform.position);

        counter.text = Convert.ToString(Convert.ToInt32(counter.text) + 1);
    }

    //~~~~~~    Удаление со сцены    ~~~~~~//
    public void Die() => Destroy(this.gameObject);
}
