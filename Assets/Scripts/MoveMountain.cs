﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMountain : MonoBehaviour
{
    float startScale, scaleMultiplier;
    bool useBuffer = true;

    [SerializeField] AudioPeer audioPeer;

    int band = 0;

    [SerializeField] Color origColor, brightColor;

    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        audioPeer = GameObject.Find("Audio").GetComponent<AudioPeer>();
        startScale = .5f;
        scaleMultiplier = .5f;
        mr = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += -transform.forward * GameManager.moveSpeed * Time.deltaTime;

        if (float.IsNaN(audioPeer.amplitude)) return;

/*            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x,
                                   (audioPeer.audioBandBuffer[band] * scaleMultiplier) + startScale,
                                    transform.localScale.z),
                                    .5f);*/

        transform.localScale = new Vector3(transform.localScale.x,
                       (audioPeer.audioBandBuffer[band] * scaleMultiplier) + startScale,
                        transform.localScale.z);

        mr.material.SetColor("_WireColor", Color.Lerp(origColor, brightColor, audioPeer.audioBandBuffer[6])); 
    }
}
