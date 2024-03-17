using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;
using Unity.Robotics.UrdfImporter.Control;

namespace RosSharp.Control
{
    public enum ControlMode { Keyboard, ROS };

    public class BotController : MonoBehaviour
    {
        public GameObject wheel1;
        public GameObject wheel2;
        public ControlMode mode = ControlMode.ROS;

        private ArticulationBody wheelA1;
        private ArticulationBody wheelA2;

        public float maxLinearSpeed = 0.15f;
        public float maxRotationalSpeed = 0.5f;
        public float wheelRadius = 0.033f;
        public float trackWidth = 0.288f;
        public float forceLimit = 10;
        public float damping = 10;

        ROSConnection ros;
        private RotationDirection direction;
        private float rosLinear = 0f;
        private float rosAngular = 0f;

        void Start()
        {
            wheelA1 = wheel1.GetComponent<ArticulationBody>();
            wheelA2 = wheel2.GetComponent<ArticulationBody>();
            SetParameters(wheelA1);
            SetParameters(wheelA2);
            ros = ROSConnection.GetOrCreateInstance();
            ros.Subscribe<TwistMsg>("/demo/cmd_vel", ReceiveROSCmd);
        }

        void ReceiveROSCmd(TwistMsg cmdVel)
        {
            rosLinear = (float)cmdVel.linear.x;
            rosAngular = (float)cmdVel.angular.z;
        }

        void FixedUpdate()
        {
            if (mode == ControlMode.Keyboard)
            {
                KeyBoardUpdate();
            }
            else if (mode == ControlMode.ROS)
            {
                ROSUpdate();
            }
        }

        private void SetParameters(ArticulationBody joint)
        {
            ArticulationDrive drive = joint.xDrive;
            drive.forceLimit = forceLimit;
            drive.damping = damping;
            joint.xDrive = drive;
        }

        private void SetSpeed(ArticulationBody joint, float wheelSpeed = float.NaN)
        {
            ArticulationDrive drive = joint.xDrive;
            if (float.IsNaN(wheelSpeed))
            {
                drive.targetVelocity = ((2 * maxLinearSpeed) / wheelRadius) * Mathf.Rad2Deg * (int)direction;
            }
            else
            {
                drive.targetVelocity = wheelSpeed;
            }
            joint.xDrive = drive;
        }

        private void KeyBoardUpdate()
        {
            float moveDirection = Input.GetAxis("Vertical");
            float inputSpeed;
            float inputRotationSpeed;
            if (moveDirection > 0)
            {
                inputSpeed = maxLinearSpeed;
            }
            else if (moveDirection < 0)
            {
                inputSpeed = maxLinearSpeed * -1;
            }
            else
            {
                inputSpeed = 0;
            }

            float turnDirction = Input.GetAxis("Horizontal");
            if (turnDirction > 0)
            {
                inputRotationSpeed = maxRotationalSpeed;
            }
            else if (turnDirction < 0)
            {
                inputRotationSpeed = maxRotationalSpeed * -1;
            }
            else
            {
                inputRotationSpeed = 0;
            }
            RobotInput(inputSpeed, inputRotationSpeed);
        }

        private void ROSUpdate()
        {
            if (rosLinear != 0 || rosAngular != 0)
                Debug.Log(rosLinear + " " + rosAngular);
            RobotInput(rosLinear, -rosAngular);
        }

        private void RobotInput(float speed, float rotSpeed)
        {
            if (speed > maxLinearSpeed)
            {
                speed = maxLinearSpeed;
            }
            if (rotSpeed > maxRotationalSpeed)
            {
                rotSpeed = maxRotationalSpeed;
            }
            float wheel1Rotation = (speed / wheelRadius);
            float wheel2Rotation = wheel1Rotation;
            float wheelSpeedDiff = ((rotSpeed * trackWidth) / wheelRadius);
            if (rotSpeed != 0)
            {
                wheel1Rotation = (wheel1Rotation + (wheelSpeedDiff / 1)) * Mathf.Rad2Deg;
                wheel2Rotation = (wheel2Rotation - (wheelSpeedDiff / 1)) * Mathf.Rad2Deg;
            }
            else
            {
                wheel1Rotation *= Mathf.Rad2Deg;
                wheel2Rotation *= Mathf.Rad2Deg;
            }
            SetSpeed(wheelA1, wheel1Rotation);
            SetSpeed(wheelA2, wheel2Rotation);
        }
    }
}
