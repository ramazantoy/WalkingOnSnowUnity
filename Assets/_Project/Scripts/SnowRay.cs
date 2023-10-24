using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeonBrave
{
    public class SnowRay : MonoBehaviour
    {
        [SerializeField] private SnowBrush _snowBrush;
        [SerializeField] private LayerMask _snowPlaneLayer;
        [SerializeField] private float distanceThreshold = 0.01f;

        private Vector2 lastHitCoordinate = Vector2.one * -1; 

        private void FixedUpdate()
        {
            Vector3 rayOrigin = transform.position; 
            Ray ray = new Ray(rayOrigin, Vector3.down); 

            Debug.DrawRay(rayOrigin, Vector3.down * 3f, Color.red); 
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 3f, _snowPlaneLayer))
            {
                Vector2 hitCoordinate = raycastHit.textureCoord;

    
                if(Vector2.Distance(lastHitCoordinate, hitCoordinate) > distanceThreshold)
                {
                    _snowBrush.HeightMapUpdate(hitCoordinate);
                    lastHitCoordinate = hitCoordinate;
                }
            }
        }
    }
}