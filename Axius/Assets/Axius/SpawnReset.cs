using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnReset : MonoBehaviour
{
    public Transform playerTransform;
    public Vector2 spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("lvl2");

    }
}


