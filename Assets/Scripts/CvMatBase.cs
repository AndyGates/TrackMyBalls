using UnityEngine;
using System.Collections;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;

public class CvMatBase : MonoBehaviour 
{
	public Action OnUpdate { get; set; }

	int m_width = 320;
	Mat m_debugMat;
	public Mat DebugMat
	{
		get { return m_debugMat; }
		set
		{		
			if(value == null) return;

			float aspect = (float)value.Height / (float)value.Width;
			int width = 320;
			int height = (int)(width * aspect);

			Size resize = new Size(width, height);

			Mat thumb =  new Mat(resize, DepthType.Cv8U, 3); 
			CvInvoke.Resize(value, thumb, resize); 
			m_debugMat = thumb;
		}
	}

	protected virtual void Update()
	{
		if(OnUpdate != null) OnUpdate(); 
	}
}
