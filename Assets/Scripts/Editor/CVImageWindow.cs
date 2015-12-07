using UnityEngine;
using System.Collections;
using UnityEditor;

public class CvImageWindow : EditorWindow 
{
	int m_width; 
	int m_height; 

	CvMatBase m_target;
	public CvMatBase Target 
	{ 
		get { return m_target; }
		set 
		{
			if(m_target != null) m_target.OnUpdate -= UpdateTexture;
			m_target = value;
			if(m_target != null) m_target.OnUpdate += UpdateTexture;
		}
	}

	public void CreateTexture()
	{
		float aspect = (float)m_target.DebugMat.Height / (float)Target.DebugMat.Width;
		m_width = 320;
		m_height = (int)(m_width * aspect);

		m_texture = new Texture2D(m_width, m_height);
	}

	Texture2D m_texture;

	public void OnGUI () 
	{
		if(Application.isPlaying && Target != null && Target.DebugMat != null && m_target != null)
		{
			if(m_texture == null) CreateTexture();
			if(m_texture != null)
			{
				GUI.DrawTexture(new Rect(0,0, m_width, m_height), m_texture);
			}
		}
	}

	public void UpdateTexture()
	{
		if(Application.isPlaying && Target != null && Target.DebugMat != null && m_target != null)
		{
			m_texture.UpdateWithMat(Target.DebugMat);
			Repaint();
		}
	}
}
