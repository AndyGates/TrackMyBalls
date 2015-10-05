using UnityEngine;
using System.Collections;
using Emgu.CV;
using Uk.Org.Adcock.Parallel;

public class MatToTexture : MonoBehaviour 
{
	[SerializeField]
	Vector2 m_position;

	[SerializeField]
	int m_width;

	Texture2D m_texture;
	Rect? m_windowRect;

	public void OnFrame(Mat image)
	{
		if(!m_texture)
		{
			float aspect = (float)image.Height / (float)image.Width;
			CreateTexture(aspect);
		}

		int channels = image.NumberOfChannels;
		byte[] pixels = image.GetData(new int[]{});
		int pixelCount = pixels.Length / channels;
		
		Color[] textureColors = new Color[pixelCount];
		
		Parallel.For(0, pixelCount,  i => 
        {
			int pixelIndex = i * channels;
			Color col;

			byte bb = pixels[pixelIndex];
			float b = (float)bb / 255.0f;

			if(channels == 1)
			{
				col = new Color(b,b,b);
			}
			else if(channels == 3)
			{
				byte gb = pixels[pixelIndex+1];
				float g = (float)gb / 255.0f;

				byte rb = pixels[pixelIndex+2];
				float r = (float)rb / 255.0f;

				col = new Color(r,g,b);
			}		
			else col = Color.magenta;
			
			textureColors[i] = col;
		});
		
		m_texture.SetPixels(textureColors);
		m_texture.Apply();
	}

	void CreateTexture(float aspect)
	{
		int height = (int)(m_width * aspect);
		m_texture = new Texture2D(m_width, height);
		//m_windowRect = new Rect(m_position.x, m_position.y, m_width, height);

		Renderer renderer = GetComponent<Renderer>();
		Material m = renderer.material;
		m.mainTexture = m_texture;
	}

	/*
	void OnGUI() 
	{
		if(m_windowRect.HasValue)
			m_windowRect = GUI.Window(0, m_windowRect.Value, WindowFunc, "TextureView");
	}

	void WindowFunc(int windowID) {
		GUI.DrawTexture(new Rect(0, 0, m_windowRect.Value.width, m_windowRect.Value.height), m_texture, ScaleMode.ScaleToFit);
	}
	*/
}
