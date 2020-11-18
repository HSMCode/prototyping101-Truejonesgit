using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheelCollider;
        public WheelCollider rightWheelCollider;
        public GameObject leftWheelMesh;
        public GameObject rightWheelMesh;
        public bool motor;
        public bool steering;
    }





	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float brakeTorque;
	public float decelerationForce;
	public float speed = 100f;

	public void ApplyLocalPositionToVisuals(AxleInfo axleInfo)
	{
		Vector3 position;
		Quaternion rotation;
		axleInfo.leftWheelCollider.GetWorldPose(out position, out rotation);
		axleInfo.leftWheelMesh.transform.position = position;
		axleInfo.leftWheelMesh.transform.rotation = rotation;
		axleInfo.rightWheelCollider.GetWorldPose(out position, out rotation);
		axleInfo.rightWheelMesh.transform.position = position;
		axleInfo.rightWheelMesh.transform.rotation = rotation;
	}

	void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical") * speed;
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		for (int i = 0; i < axleInfos.Count; i++)
		{
			if (axleInfos[i].steering)
			{
				Steering(axleInfos[i], steering);
			}
			if (axleInfos[i].motor)
			{
				Acceleration(axleInfos[i], motor);
			}
			if (Input.GetKey(KeyCode.Space))
			{
				Brake(axleInfos[i]);
			}
			ApplyLocalPositionToVisuals(axleInfos[i]);
		}
	}

	private void Acceleration(AxleInfo axleInfo, float motor)
	{
		if (motor != 0f)
		{
			axleInfo.leftWheelCollider.brakeTorque = 0;
			axleInfo.rightWheelCollider.brakeTorque = 0;
			axleInfo.leftWheelCollider.motorTorque = motor;
			axleInfo.rightWheelCollider.motorTorque = motor;
		}
		else
		{
			Deceleration(axleInfo);
		}
	}

	private void Deceleration(AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = decelerationForce;
		axleInfo.rightWheelCollider.brakeTorque = decelerationForce;
	}

	private void Steering(AxleInfo axleInfo, float steering)
	{
		axleInfo.leftWheelCollider.steerAngle = steering;
		axleInfo.rightWheelCollider.steerAngle = steering;
	}

	private void Brake(AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = brakeTorque;
		axleInfo.rightWheelCollider.brakeTorque = brakeTorque;
	}









	/*public Rigidbody rb;
    public Transform car;
    public float speed = 17;
    public float rotationSpeed = 10f;


    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = -transform.forward * speed;
        }

        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }

    }

    */


}
