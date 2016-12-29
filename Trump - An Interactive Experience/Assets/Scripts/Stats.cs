using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

    // Use this for initialization
    private int _badHombreSpawnCount;
    private int _cameraManSpawnCount;

    private int _badHombreKillCount;
    private int _cameraManKillCount;

    void Start ()
    {
        Reset();
    }
	
	public void Reset ()
    {
        _badHombreSpawnCount = 0;
        _cameraManSpawnCount = 0;

        _badHombreKillCount = 0;
        _cameraManKillCount = 0;
    }

    public void BadHombreKilled()
    {
        _badHombreKillCount++;
    }
    public void BadHombreSpawned()
    {
        _badHombreSpawnCount++;
    }
    public void CameraManKilled()
    {
        _cameraManKillCount++;
    }
    public void CameraManSpawned()
    {
        _cameraManSpawnCount++;
    }

    public int BadHombreSpawnCount
    {
        get
        {
            return _badHombreSpawnCount;
        }
    }
    public int BadHombreKillCount
    {
        get
        {
            return _badHombreKillCount;
        }
    }
    public int CameraManSpawnCount
    {
        get
        {
            return _cameraManSpawnCount;
        }
    }
    public int CameraManKillCount
    {
        get
        {
            return _cameraManKillCount;
        }
    }
}
