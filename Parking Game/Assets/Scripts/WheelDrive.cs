using UnityEngine;
using System;

[Serializable]
public enum DriveType
{
   RearWheelDrive,
   FrontWheelDrive,
   AllWheelDrive
}

public class WheelDrive : MonoBehaviour
{
	[Tooltip("최대 휠 각도")]
	public static float maxAngle = 30f;
	[Tooltip("최대 휠 힘")]
	public static float maxTorque = 150f;
	[Tooltip("최대 브레이크 힘")]
	public static float brakeTorque = 70000f;
	[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
	public GameObject wheelShape;

	public float wheelangle = 0.0f;

	[Tooltip("물리 엔진이 다른 양의 하위 단계 (m / s)를 사용할 수있을 때의 차량 속도.")]
	public float criticalSpeed = 5f;
	[Tooltip("속도가 중요 이상일 때 시뮬레이션 하위 단계.")]
	public int stepsBelow = 5;
	[Tooltip("속도가 임계 값 미만인 경우 시뮬레이션 하위 단계.")]
	public int stepsAbove = 1;

	[Tooltip("차량 구동 유형 : 후륜 구동, 전륜 구동 또는 전륜 구동.")]
	public DriveType driveType;
	
    private WheelCollider[] m_Wheels;

    // hierarchy에서 모든 WheelCollider 찾기 .
	void Start()
   	{
    	m_Wheels = GetComponentsInChildren<WheelCollider>();

	    for (int i = 0; i < m_Wheels.Length; ++i) 
    	{
        	var wheel = m_Wheels [i];

    	    // Create wheel shapes only when needed.
       		if (wheelShape != null)
       		{
 	    	var ws = Instantiate (wheelShape);
           	ws.transform.parent = wheel.transform;
        	}
	    }
	}

// 이것은 바퀴를 업데이트하는 정말 간단한 방법입니다.
// 우리는 뒷바퀴 구동 자동차를 시뮬레이션하고 자동차가 로컬 제로에서 완벽하게 대칭이라고 가정합니다.
// 이것은 어느 바퀴가 앞 바퀴이고 어떤 바퀴가 뒷 바퀴인지 알아내는 데 도움이됩니다.

   // This is a really simple approach to updating wheels.
   // We simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero.
   // This helps us to figure our which wheels are front ones and which are rear.
    void Update()
	{
		float torque = 0.0f;
		m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

				//a = 0 ~ 1, d = -1 ~ 0 회전힘 300f
				//누르는 만큼 -30~0 , 0~30 사이의 값이 angle로 들어감
	
		if (Input.GetAxis("Horizontal") > 0){
			wheelangle += 1.11f;
		}
		if (Input.GetAxis("Horizontal") < 0){
			wheelangle -= 1.11f;
		}
		if (wheelangle >= 30f){
			wheelangle = 30f;
		}
		if (wheelangle <= -30f){
			wheelangle = -30f;
		}
		
		if (Input.GetKey(KeyCode.W)){
			// 기어상태(1일때 전진, -1일때 후진, 0일 때 주차)를 최대 토크에 곱해서 현재 토크 설정
			torque = maxTorque * GearManager.GearStatus; 
		}
		//x누르면 브레이크 힘 30000f
		float handBrake = Input.GetKey(KeyCode.S) ? brakeTorque : 0;
		if (Input.GetKey(KeyCode.S)) {
			handBrake = brakeTorque;
			torque = 0.0f;
		}
		foreach (WheelCollider wheel in m_Wheels)
		{
			if (wheel.transform.localPosition.z > 0){
				wheel.steerAngle = wheelangle;
			}

			//후진시 이정도의 힘으로 brakeTorque을 설정
			if (wheel.transform.localPosition.z < 0)
			{
				wheel.brakeTorque = handBrake;
			}

			//후진일때 
			if (wheel.transform.localPosition.z < 0 && driveType != DriveType.FrontWheelDrive)
			{
				//모터의 힘
				wheel.motorTorque = torque;
			}

			//전진일때 
			if (wheel.transform.localPosition.z >= 0 && driveType != DriveType.RearWheelDrive)
			{
				//모터의 힘
				wheel.motorTorque = torque;
			}

			// Update visual wheels if any.
			if (wheelShape) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// Assume that the only child of the wheelcollider is the wheel shape.
				Transform shapeTransform = wheel.transform.GetChild (0);

					if (wheel.name == "a0l" || wheel.name == "a1l" || wheel.name == "a2l")
					{
						shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
						shapeTransform.position = p;
					}
					else
					{
						shapeTransform.position = p;
						shapeTransform.rotation = q;
					}
			}
		}
  	}
}