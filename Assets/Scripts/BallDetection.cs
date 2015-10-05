using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//using OpenCvSharp;

public class BallDetection : MonoBehaviour 
{
	/*
	[SerializeField]
	List<ThresholdFilter> m_filters = new List<ThresholdFilter>();

	Mat m_src;
	Mat m_hsv;

	VideoCapture m_cap;

	void Awake()
	{
		Debug.Log(AppDomain.CurrentDomain.BaseDirectory);
		//string info = Cv2.GetBuildInformation();
		
		string vurl = "C:\\Users\\Andrew\\Desktop\\brk2.mp4";
		//vurl = "Assets//Images//sample.avi";
		
		m_cap = new VideoCapture(vurl);
		Debug.Log ("Cap opened: " + m_cap.IsOpened());

		var test = m_cap.Format;
		Debug.Log(test);
	}


	// Use this for initialization
	void Start () 
	{
		for(int f = 0; f < 200; f++)
		{
			GetFrame();
		}
		
		string url = "assets//Images//poolbreak.jpg";
		url = "assets//Images//pool.png";
		url = "assets//Images//fullwidth.jpg";

		m_src = new Mat(url);
		m_hsv = new Mat();

		float aspect = (float)m_src.Height / (float)m_src.Width;
		float w = 480;
		float h = w * aspect;

		Cv2.Flip(m_src, m_src, FlipMode.Y);
		Cv2.Resize(m_src, m_src, new Size(w, h));

		Cv2.CvtColor(m_src, m_hsv, ColorConversionCodes.BGR2HSV);
		Cv2.ImShow("HSV", m_hsv);
		//Cv2.ImShow("Src", m_src);

		foreach(ThresholdFilter filter in m_filters)
		{
			filter.ApplyFilter(m_hsv);
		}
	}

	void GetFrame()
	{
		try
		{		
			Mat vidMat = Mat.Zeros(new Size(640, 360), MatType.CV_32FC4);
			m_cap.Read(vidMat);
			Cv2.ImShow("Vid", vidMat);
		}
		catch(Exception e)
		{
			Exception exp = e;
			Debug.Log (exp);
			Debug.Log(e.Message);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	*/
}
