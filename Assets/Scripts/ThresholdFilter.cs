using UnityEngine;
using System.Collections;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.Util;

public class ThresholdFilter : MonoBehaviour 
{
	[SerializeField]
	string m_name;

	[Range(0, 256)]
	[SerializeField]
	int m_hmin = 0;
	
	[Range(0, 256)]
	[SerializeField]
	int m_hmax = 256;
	
	[Range(0, 256)]
	[SerializeField]
	int m_smin = 0;
	
	[Range(0, 256)]
	[SerializeField]
	int m_smax = 256;
	
	[Range(0, 256)]
	[SerializeField]
	int m_vmin = 0;

	[Range(0, 256)]
	[SerializeField]
	int m_vmax = 256;
	
	[SerializeField]
	MatEvent m_onFrame;

	public void ApplyFilter(Mat src)
	{
		CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Hsv);

		Mat threshold = new Mat(src.Height, src.Width, src.Depth, src.NumberOfChannels);
		MCvScalar min = new MCvScalar(m_hmin, m_smin, m_vmin);
		MCvScalar max = new MCvScalar(m_hmax, m_smax, m_vmax);

		CvInvoke.InRange(src, new ScalarArray(min), new ScalarArray(max), threshold);

		//Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3,3), Point.Empty);
		//CvInvoke.Erode(threshold, threshold, element, Point.Empty, 1, BorderType.Constant, new MCvScalar(1.0f));
		//CvInvoke.Canny(threshold, threshold, 100, 255);

		VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
		Mat hierarchy = new Mat();

		//CvInvoke.FindContours(threshold, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple, Point.Empty);

		Mat draw = new Mat(src.Height, src.Width, src.Depth, src.NumberOfChannels);

		int i = 0;

		var contoursArray = contours.ToArrayOfArray();
		foreach(Point[] contour in contoursArray)
		{
			//CvInvoke.DrawContours(draw, contours, i, new MCvScalar(0.0, 1.0, 0.0), 1, LineType.EightConnected, null, int.MaxValue, Point.Empty);

         	double a = CvInvoke.ContourArea(new VectorOfPoint(contour));
			//Debug.Log("Contour: " + a);
			i++;
		}

		if(m_onFrame != null) m_onFrame.Invoke(threshold);
	}
}
