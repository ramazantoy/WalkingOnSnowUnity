using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 10f; 
        private Vector3 offset; 

        void Start()
        {
            offset = transform.position - target.position; 
        }

        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset; 
            Vector3 smoothedPosition =
                Vector3.Lerp(transform.position, desiredPosition,
                    smoothSpeed * Time.deltaTime); 

            transform.position = smoothedPosition; 
        }
    }
}