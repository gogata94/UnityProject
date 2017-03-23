using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.IO.Ports;


public class ShoulderControler : MonoBehaviour {
	private SerialPort USBIO ;
	public Transform Shoulder;
	public string[] inputData;
	Vector3 rotationSh;
	// Use this for initialization
	void Start () {
		inputData = new string[2];
		rotationSh = new Vector3();

		USBIO = new SerialPort ();
		USBIO.PortName = "COM4";
		USBIO.BaudRate = 9600;
		USBIO.Parity = Parity.Odd;
		USBIO.DataBits = 8;
		USBIO.Handshake = Handshake.None;
		USBIO.StopBits = StopBits.One;

		USBIO.ReadTimeout = 100000;
		USBIO.WriteTimeout = 100000;

		USBIO.Open ();


	}
	
	// Update is called once per frame
	void Update () {
		getInput ();
	}
	private void getInput () {
		int i;
		for (i = 0; i < 2 ; i++) {
			if (String.IsNullOrEmpty(inputData[i])) {
				inputData[i] = "0";
			}
		}

		USBIO.Write ("A");
		for (i = 0; i < inputData.Length; i++) {
			inputData[i] = USBIO.ReadLine ();
		}

		rotationSh.x = float.Parse (inputData [0]);
		rotationSh.y = float.Parse (inputData [1]);
		rotationSh.z = 0.0f;

		Shoulder.transform.rotation = Quaternion.Euler (rotationSh);
	}
}
