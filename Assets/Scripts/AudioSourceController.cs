using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    private int index;

    void Start()
    {
        audioSources = GetComponent<AudioSource[]>();
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            index++;
            index %= 3;
        }

        if (Input.GetMouseButton(0))
        {
            switch (index)
            {
                case 0:
                    audioSources[0].Play();
                    break;
                case 1:
                    audioSources[1].Play();
                    break;
                case 2:
                    audioSources[0].Play();
                    break;

            }
        }
    }
}
