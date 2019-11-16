using System;
using UnityEngine;

public class Paralaxing : MonoBehaviour
{
    [Range(0, 10)]
    public float ParallaxSmoothing = 1f;

    public Transform[] Backgrounds;

    private Vector3 _camPos;
    private Vector3 _lastCamPos;
    private float _camSize;

    private void Start()
    {
        _camPos = transform.position;
        _lastCamPos = transform.position;

        _camSize = GetComponent<Camera>().orthographicSize;

        /* Change the backgrounds distance to the camera (z-axis) to create depth.
         * The amount changes per background to create different detpths between
         * the backgrounds. */

        for (int i = 0; i < Backgrounds.Length; i++)
        { Backgrounds[i].position = new Vector3(Backgrounds[i].position.x, Backgrounds[i].position.y, 5 * i); }
    }

    private void Update()
    {
        _camPos = transform.position;


        /* Calculates how much to move the background depending on the distance 
         * from the camera, how much the camera moved since the last frame and 
         * the parallax smoothing */

        foreach (Transform background in Backgrounds)
        {
            float parallax = (_lastCamPos.x - _camPos.x) * GetParalaxScale(background);
            float backgroundTargetPosX = background.position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, background.position.y, background.position.z);
            background.position = Vector3.Lerp(background.position, backgroundTargetPos, ParallaxSmoothing * Time.deltaTime);
        }

        _lastCamPos = _camPos;
    }

    public static float GetParalaxScale(Transform t)
    {
        return t.position.z * -1;
    }
}
