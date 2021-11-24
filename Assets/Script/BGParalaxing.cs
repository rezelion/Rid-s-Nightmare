using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParalaxing : MonoBehaviour
{

    public Transform[] BG; // Array list of BG & FG
    private float[] paralaxScales; //the proportion of camera movement to move bg
    public float smoothing = 1f;     // smooth parallax

    private Transform cam;
    private Vector3 previousCamPos;

    
    private void Awake()
    {
        // set up cam reference
        cam = Camera.main.transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        paralaxScales = new float[BG.Length];
        for(int i = 0; i < BG.Length; i++)
        {
            paralaxScales[i] = BG[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < BG.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * paralaxScales[i];

            float backgroundTargetPosX = BG[i].position.x + parallax;

            Vector3 BGTargetPos = new Vector3(backgroundTargetPosX, BG[i].position.y, BG[i].position.z);

            BG[i].position = Vector3.Lerp(BG[i].position, BGTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}
