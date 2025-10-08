using UnityEngine;

public class PlayerTurretInstaller : MonoBehaviour
{
    [SerializeField] private InstallPoint[] _installPoints;

    [SerializeField] private GameObject _lightTurretPrefab;
    [SerializeField] private GameObject _heavyTurretPrefab;
    [SerializeField] private GameObject _rocketTurretPrefab;

    [ContextMenu("Install Light Turret")] private void InstallLightTurret() => Install(_lightTurretPrefab);
    [ContextMenu("Install Heavy Turret")] private void InstallHeavyTurret() => Install(_heavyTurretPrefab);
    [ContextMenu("Install Rocket Turret")] private void InstallRocketTurret() => Install(_rocketTurretPrefab);

    private void Install(GameObject turretPrefab)
    {
        InstallPoint installPoint = TryGetFreePoint();

        if (installPoint != null)
        {
            InstallAtPoint(installPoint, turretPrefab);
        }
        else
        {
            RealesePoint(_installPoints[0]);
            InstallAtPoint(_installPoints[0], turretPrefab);
        }
    }

    private InstallPoint TryGetFreePoint()
    {
        foreach (var point in _installPoints)
        {
            if (!point.IsOccupied)
                return point;
        }

        return null;
    }

    private void RealesePoint(InstallPoint installPoint)
    {
        installPoint.Realese();
    }

    private void InstallAtPoint(InstallPoint installPoint, GameObject turretPrefab)
    {
        GameObject turret = Instantiate(turretPrefab);
        turret.GetComponent<InstallPointFollower>().Initialize(installPoint.transform);

        installPoint.InstallObject(turret);
    }
}
