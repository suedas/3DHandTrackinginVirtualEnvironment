using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;


   //�izgilerin boyutlar� belirleniyor 
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    
    //ba�lang�� ve biti� noktalr� belirleniyor 
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
    }
}
