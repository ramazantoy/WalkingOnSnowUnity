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



        private void FixedUpdate()
        {
            Vector3 rayOrigin = transform.position; // Ray'ı kendi pozisyonunuzdan başlatın.
            Ray ray = new Ray(rayOrigin, Vector3.down); // Aşağı doğru bir ışın oluşturun.

            Debug.DrawRay(rayOrigin, Vector3.down * 30f, Color.red); // Debug ile ışının yönünü görselleştirin.

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _snowPlaneLayer))
            {
                
                Vector2 hitCoordinate = raycastHit.textureCoord;
                _snowBrush.HeightMapUpdate(hitCoordinate);
              
            }
        }
    }
}


