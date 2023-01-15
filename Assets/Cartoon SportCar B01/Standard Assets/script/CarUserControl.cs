using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        float frontRight;
        float frontLeft;
        float backRight;
        float backLeft;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            backLeft = Input.GetKey(KeyCode.A) ? 1 : 0;
            frontLeft = Input.GetKey(KeyCode.W) ? 1 : 0;
            frontRight = Input.GetKey(KeyCode.E) ? 1 : 0;
            backRight = Input.GetKey(KeyCode.F) ? 1 : 0;

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(frontLeft, frontRight, backLeft, backRight, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
