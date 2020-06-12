using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
   public Transform[] WayPoints;

   public float SpeedMove = 0.25f;
   public float SpeedRotate = 5f;

   private int _count = 0;

   private void Update()
   {
      this.transform.position = Vector3.MoveTowards(this.transform.position, WayPoints[_count].position, Time.deltaTime * SpeedMove);
      this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, WayPoints[_count].rotation, Time.deltaTime * SpeedRotate);

      if (this.transform.position == WayPoints[_count].position && this.transform.rotation == WayPoints[_count].rotation)
         _count++;
   }
}
