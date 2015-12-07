using UnityEngine;
using System.Collections;
using Emgu.CV;

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

		m_texture.UpdateWithMat(image);
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
}
