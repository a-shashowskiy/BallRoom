using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour, ISelector
{
    public int forseToPush { get; set; }
    [SerializeField] private string selectableTag = "Ball";
    Ball selectedObject;
   
    // Update is called once per frame
    void Update()
    {
        selectedObject = Select();
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject != null)
            {
                selectedObject.PushBall( Vector3.ProjectOnPlane(-Camera.main.ScreenPointToRay(Input.mousePosition).direction, Vector3.up  ), forseToPush);
            }
        }
    }
 
    public Ball Select()
    {
        Ball s = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
        {
            if (hit.transform.CompareTag(selectableTag))
            { 
                s =  hit.transform.GetComponent<Ball>();
            }
            else
                s = null;
        }
        else
            s = null;

        return s;
    }
}
