using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    public ChooseCar car;
    private void FixedUpdate()
    {

        HandleTranslation();
        HandleRotation();


        target = car.choosen_car;
    }

    private void HandleTranslation()
    {
        if (target != null)
        {
            var targetPosition = target.transform.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        }
    }
    private void HandleRotation()
    {

        if (target != null)
        {
            var direction = target.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
