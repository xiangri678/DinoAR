using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class CarBehaviour : MonoBehaviour
{
    public ReticleBehaviour Reticle;
    public float Speed = 1.2f;
    private RaptorSoundEffects _raptorSoundEffects;
    private Animator dinoAnim;
    private string[] animNames = {"roaring", "hitting2", "hitting3", "biting", "calling"};
    private string currentAnim;
    private bool idle = true;

    private void Start()
    {
        _raptorSoundEffects = GetComponent<RaptorSoundEffects>();
        _raptorSoundEffects.Growl();
        dinoAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        var trackingPosition = Reticle.transform.position;
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1) // 原0.02
        {
            if (idle != true)
            {
                dinoAnim.SetBool("run",false);
                idle = true;
            }
            return;
        }

        if (idle == true)
        {
            dinoAnim.SetBool("run",true);
            dinoAnim.SetTrigger("running");
            idle = false;
        }

        // 旋转180度，方向才正
        var lookRotation = Quaternion.LookRotation(transform.position - trackingPosition);
        // var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        // lookRotation *= Quaternion.Euler(0, 180, 0); 
        transform.rotation =
            Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        transform.position =
            Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime * 0.6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var Gem = other.GetComponent<GemBehaviour>();
        if (Gem != null)
        {
            int index = UnityEngine.Random.Range(0, animNames.Length);
            currentAnim = animNames[index];
            dinoAnim.SetBool("roaring",true);
            _raptorSoundEffects.PlayRandomSound();
            Destroy(other.gameObject);
        }
    }

    private void GetGemRoar()
    {
        dinoAnim.SetBool("roaring",false);
        
    }
}

