using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : GenericCharacterMovementScript
{
    public static PlayerMovementScript instance;

 

    public Transform[] relativePositioningTargets;

    public void Awake()
    {
        PlayerMovementScript.instance = this;
    }
    public override void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        base.Move();
    }

    public override void FiringInput()
    {
        firing = Input.GetKey(KeyCode.Mouse0);
    }
    public override void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            shootingDirection.LookAt(hit.point); // Look at the point
            shootingDirection.rotation = Quaternion.Euler(new Vector3(0, shootingDirection.rotation.eulerAngles.y, 0)); // Clamp the x and z rotation
        }
    }
}
