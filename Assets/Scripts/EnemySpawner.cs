using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEditor.VersionControl.Message;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InvokeRepeating("SpawnTester", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy(int type, Path path)
    {
        // Randomly choose between Path1 and Path2
        Path selectedPath = UnityEngine.Random.Range(0, 2) == 0 ? Path.Path1 : Path.Path2;


        var newEnemy = Instantiate(Enemies[type], Path1[0].transform.position, Path1[0].transform.rotation);
        var script = newEnemy.GetComponentInParent<Enemy>();
        // set hier het path en target voor je enemy in 
        script.path = selectedPath; // Set the path
        script.target = RequestTarget(selectedPath, 1);
    }

    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1);
    }

    public GameObject RequestTarget(Path path, int index)
    {
        // schrijf deze code zelf 
        List<GameObject> selectedPath = path == Path.Path1 ? Path1 : Path2;
        if (index < selectedPath.Count)
            return selectedPath[index];
        else
            return null;
    }

}
