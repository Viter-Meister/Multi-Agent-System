using RosMessageTypes.Geometry;
using RosMessageTypes.Std;
using Unity.Robotics.Core;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public static class TransformExtensions
{
    public static TransformMsg ToROSTransform(this Transform tfUnity)
    {
        return new TransformMsg(
            tfUnity.localPosition.To<FLU>(),
            tfUnity.localRotation.To<FLU>());
    }

    public static TransformStampedMsg ToROSTransformStamped(this Transform tfUnity, double timeStamp)
    {
        return new TransformStampedMsg(
            new HeaderMsg(new TimeStamp(timeStamp), tfUnity.parent.gameObject.name),
            tfUnity.gameObject.name,
            tfUnity.ToROSTransform());
    }
}
