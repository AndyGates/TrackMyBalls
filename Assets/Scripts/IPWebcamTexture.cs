using UnityEngine;
using System.Collections;
//using OpenCvSharp;
//using Uk.Org.Adcock.Parallel;

public class IPWebcamTexture : MonoBehaviour 
{
	/*
	[SerializeField]
	string m_uri = "http://192.168.0.5:8080/shot.jpg";
	//string m_uri = "http://unity3d.com/profiles/unity3d/themes/unity/images/company/pr/unity-market-share-B-1.png";

	[SerializeField]
	Vector2 m_size = new Vector2(800, 600);

	Texture2D m_targetTexture;

	public Mat WebcamMat { get; private set; }

	public void Start()
	{
		var renderer = GetComponent<Renderer>();
		if(renderer != null)
		{
			m_targetTexture = new Texture2D((int)m_size.x, (int)m_size.y, TextureFormat.RGB24, false);
			renderer.material.mainTexture = m_targetTexture;

			WebcamMat = new Mat(new Size(m_size.x, m_size.y), MatType.CV_32FC3); 

			StartCoroutine(Fetch());
		}
	}

	public IEnumerator Fetch() 
	{
		Debug.Log("fetching... "+Time.realtimeSinceStartup);

		while(true)
		{
			yield return new WaitForSeconds(0.3f);
			WWW www = new WWW(m_uri);
			yield return www;

			if(!string.IsNullOrEmpty(www.error))
				throw new UnityException(www.error);
			
			www.LoadImageIntoTexture(m_targetTexture);

			UpdateMat();
		}
	}	

	void UpdateMat()
	{
		var width = m_targetTexture.width;
		var height = m_targetTexture.height;
		var pixels = m_targetTexture.GetPixels();
		Parallel.For(0, height, i =>
		             {
			for (var j = 0; j < width; j++)
			{
				var pixel = pixels[j + i * width];
				var col = new Scalar
				{
					Val0 = (double)pixel.b,
					Val1 = (double)pixel.g,
					Val2 = (double)pixel.r,
				};
				
				WebcamMat.Set(i, j, col);
			}
		});	

		Cv2.ImShow("CAM", WebcamMat);
	}
	*/
}
