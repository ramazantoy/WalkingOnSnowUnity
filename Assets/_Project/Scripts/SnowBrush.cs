
using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
namespace LeonBrave{

public class SnowBrush : MonoBehaviour
{

    public CustomRenderTexture SnowHeightMap;
    public Material HeigtMapUpdate;

    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    private static readonly int RemovePosition = Shader.PropertyToID("_RemovePosition");

    private List<Vector4> _hitCordinate = new List<Vector4>();

    [SerializeField]
    private float _removeTime;

    [SerializeField]
    private int _startRemoveCount;
    

    private void Start()
    {
        SnowHeightMap.Initialize();
    }
    
    public void HeightMapUpdate(Vector4 hitCordinate)
    {
    
        _hitCordinate.Add(hitCordinate);
        HeigtMapUpdate.SetVector(DrawPosition,hitCordinate);
  
   
    }
    

    private float _timer = 0f;
    
    private void Update()
    {
        if (_hitCordinate.Count <= _startRemoveCount)
        {
            return;
        }

        _timer += Time.deltaTime;
        if (_timer >= _removeTime)
        {
            _timer = 0f;

            Vector4 removePoint = _hitCordinate[0];
            _hitCordinate.RemoveAt(0);
            
            HeigtMapUpdate.SetVector(RemovePosition,removePoint);
        }


    }


    private void OnApplicationQuit()
    {
        HeigtMapUpdate.SetVector(DrawPosition,new Vector4(-1,-1,0,0));
        SnowHeightMap.Initialize();
    }
}

}
