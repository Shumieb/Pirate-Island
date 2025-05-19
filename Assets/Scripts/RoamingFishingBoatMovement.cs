using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class RoamingFishingBoatMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3f;

    [SerializeField] float rotationSpeed = 30f;

    [SerializeField] bool movingToNextPoint = true;

    [SerializeField] float waitTime = 8f;
    [SerializeField] float countDownTimer = 0f;

    [SerializeField] Transform[] movePoints;

   [SerializeField] Transform selectedPoint;

    private int selectedPointIndex = 0;
    private int maxPointsIndex;

    private void Start()
    {
        maxPointsIndex = movePoints.Length - 1;
        movingToNextPoint = true;
        RotateBoat();
    }

    void FixedUpdate()
    {        
        if(movingToNextPoint)
        {
            MoveBoat();
        }

        if(transform.position ==  selectedPoint.position)
        { 
            if(countDownTimer <  waitTime)
            {
                movingToNextPoint = false;
                countDownTimer += Time.deltaTime;
            }           
        }

        if(countDownTimer >= waitTime && !movingToNextPoint)
        {
                selectedPoint = UpdateSelectedPoint();
                RotateBoat();
                movingToNextPoint = true;
                countDownTimer = 0;
        }
    }

    private Transform UpdateSelectedPoint() 
    { 
        // get the new index
        int nextIndex = UpdateSelectedPointIndex();
        return movePoints[nextIndex];
    }

    private int UpdateSelectedPointIndex()
    {
        if (selectedPointIndex < maxPointsIndex)
        {
            selectedPointIndex++;
        }
        else
        {
           selectedPointIndex = 0;
        }

        return selectedPointIndex;
    }
  
    private void RotateBoat()
    {
        Vector2 direction = selectedPoint.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(selectedPoint.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveBoat()
    {
        transform.position = Vector2.MoveTowards(transform.position, selectedPoint.position, moveSpeed * Time.deltaTime);
    }
}
