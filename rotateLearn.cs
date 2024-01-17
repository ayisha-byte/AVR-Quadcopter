using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;


public class rotateLearn : MonoBehaviour
{

    public AudioSource DroneSound;
    [SerializeField]
    private OVRInput.Controller m_controllerMenu;
    [SerializeField]
    private float m_time_start;

    GameObject m_prop1;
    GameObject m_prop2;
    GameObject m_prop3;
    GameObject m_prop4;
    GameObject m_sun;
    GameObject m_sune;


    private bool m_button1_activated;
    private bool m_button2_activated;
    private bool m_button4_activated;
    private bool m_button3_activated;



    private Quaternion m_initialPropRotation;
    private Quaternion m_initialSunRotation;

    void Start()
    {
        m_prop1 = GameObject.Find("Propeller1");
        m_prop2 = GameObject.Find("Propeller2");
        m_prop3 = GameObject.Find("Propeller3");
        m_prop4 = GameObject.Find("Propeller4");
        m_sun = GameObject.Find("EarthGlobe");
        m_sune = GameObject.Find("Sun");


        m_time_start = Time.time;

        m_initialPropRotation = m_prop1.transform.rotation;
        m_initialSunRotation = m_sun.transform.rotation;
        m_initialSunRotation = m_sune.transform.rotation;


        DebugUIBuilder.instance.AddButton("Button 1", () => { m_button1_activated = true; });
        DebugUIBuilder.instance.AddButton("Button 2", () => { m_button2_activated = true; });
        DebugUIBuilder.instance.AddButton("Button 3", () => { m_button3_activated = true; });
        DebugUIBuilder.instance.AddButton("Button 4", () => { m_button4_activated = true; });

        DebugUIBuilder.instance.Show();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_controllerMenu))
        {
            m_button1_activated = true;

        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, m_controllerMenu))
        {
            m_button2_activated = true;

        }

        if (OVRInput.GetDown(OVRInput.Button.Start, m_controllerMenu))
        {
            m_button4_activated = true;
        }

        if (OVRInput.GetDown(OVRInput.Button.Start, m_controllerMenu))
        {
            m_button3_activated = true;
        }

        if (m_button1_activated)
        {
            DroneSound.Play();
            RotateProps();
            
        }

        if (m_button2_activated)
        {
            DroneSound.Play();
            RotateDrone();

        }

        if (m_button3_activated)
        {
            DroneSound.Play();
            RotateAround();

        }

        if (m_button4_activated)
        {
            //DroneSound.Stop();
            ResetAll();

        }

    }

    void RotateProps()
    {
        // Your propeller rotation logic here
        Quaternion myQ1;
        float curr_time = Time.time;
        float deg;
        float deg_per_sec;

        deg_per_sec = 2000;
        deg = (m_time_start - curr_time) * deg_per_sec;
        myQ1 = Quaternion.AngleAxis(deg, new Vector3(0.0f, 1.0f, 0.0f));
        m_prop1.transform.rotation = myQ1;
        m_prop2.transform.rotation = myQ1;
        m_prop3.transform.rotation = myQ1;
        m_prop4.transform.rotation = myQ1;
    }

    void RotateDrone()
    {
    // Rotate propellers
      RotateProps();

      // Rotate drone body
      Quaternion myQ1;
      float curr_time = Time.time;
      float deg;
      float deg_per_sec;

      deg_per_sec = 15;
      deg = (m_time_start - curr_time) * deg_per_sec;
      myQ1 = Quaternion.AngleAxis(deg, new Vector3(0.0f, 1.0f, 0.0f));
      m_sun.transform.rotation = myQ1;

    }

    void RotateAround(){
      //roatte the drone around

        Quaternion myQ1;
        float curr_time = Time.time;
        float deg;
        float deg_per_sec;

        deg_per_sec = 2000;
        deg = (m_time_start - curr_time) * deg_per_sec;
        myQ1 = Quaternion.AngleAxis(deg, new Vector3(0.0f, 1.0f, 0.0f));
        m_prop1.transform.rotation = myQ1;
        m_prop2.transform.rotation = myQ1;
        m_prop3.transform.rotation = myQ1;
        m_prop4.transform.rotation = myQ1;


        deg_per_sec = 15;
        deg = (m_time_start - curr_time) * deg_per_sec;
        myQ1 = Quaternion.AngleAxis(deg, new Vector3(0.0f, 1.0f, 0.0f));
        m_sune.transform.rotation = myQ1;
    }



    void ResetAll()
    {
      //stop all movements
        m_button1_activated = false;
        m_button2_activated = false;
        m_button4_activated = false;
        m_button3_activated = false;



    }
}
