using UnityEngine;
using System.Collections;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour 
{
	static T m_instance;
	public static T Instance
	{
		get 
		{
			if(m_instance == null)
			{
				GameObject go = new GameObject() { hideFlags = HideFlags.HideAndDontSave };
				m_instance = go.AddComponent<T>();
			}
			return m_instance;
		}
	}

	public virtual void CleanUp()
	{
		Destroy(m_instance.gameObject);
		m_instance = null;
	}
}
