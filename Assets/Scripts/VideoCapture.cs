using UnityEngine;
using System.Collections;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Uk.Org.Adcock.Parallel;
using UnityEngine.Events;

public class VideoCapture : MonoBehaviour
{
	[System.Serializable]
	public enum VideoCaptureType
	{
		Webcam,
		FileStream
	}
	
	[SerializeField]
	VideoCaptureType m_captureType;

	[SerializeField]
	int m_webcamIndex;

	[SerializeField]
	string m_streamUrl;

	[SerializeField]
	MatEvent m_onFrame;

	[SerializeField]
	int m_resizeWidth = 640;

	[SerializeField]
	ThresholdFilter m_filter;

	Capture m_cap;
	
	int m_originalWidth;
	int m_originalHeight;
	
	int m_width;
	int m_height;

	bool m_running;
	
	// Use this for initialization
	void Start () 
	{
		OpenCapture();

		m_originalWidth = (int)m_cap.GetCaptureProperty(CapProp.FrameWidth);
		m_originalHeight = (int)m_cap.GetCaptureProperty(CapProp.FrameHeight);
		
		float aspect = (float)m_originalHeight / (float)m_originalWidth;
		m_width = m_resizeWidth;
		m_height = (int)((float)m_width * aspect);
		
		m_running = true;
	}

	void OpenCapture()
	{
		if(m_captureType == VideoCaptureType.FileStream)
		{
			m_cap = new Capture(m_streamUrl);
		}
		else
		{
			m_cap = new Capture(m_webcamIndex);
		}

		if(m_cap == null) m_running = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(m_running)
		{
			Mat image = new Mat(new System.Drawing.Size(m_originalWidth, m_originalHeight), DepthType.Cv8U, 3);  
			image = m_cap.QueryFrame();

			if(image == null || image.IsEmpty)
			{
				OpenCapture();
				return;
			}
			
			Mat smaller = new Mat(new System.Drawing.Size(m_width, m_height), DepthType.Cv8U, 3);
			CvInvoke.Resize(image, smaller, new System.Drawing.Size(m_width, m_height));
			CvInvoke.Flip(smaller, smaller, FlipType.Vertical);

			if(m_onFrame != null) m_onFrame.Invoke(smaller);

			m_filter.ApplyFilter(smaller);
		}
	}
}
