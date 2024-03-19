using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    public float speed = 70f;

    public GameObject impactEffect;

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Debug.Log("Hit something");
        Destroy(_target.gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
