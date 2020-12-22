using UnityEngine;

public static class CameraRayCasterPoint
{
    public static bool RayCastPointInCamera(Vector3 point)
    {
        RaycastHit hit;

        var camera = Camera.main;
        var cameraPosition = camera.transform.position;
        var direction = (point - cameraPosition).normalized;
        
        if (Physics.Raycast(cameraPosition, direction, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(cameraPosition, hit.point);
            var angle = Vector3.Angle(camera.transform.forward, direction);
            if (hit.point == point || angle < camera.fieldOfView / 2)
                return false;
        }

        return true;
    }
}
