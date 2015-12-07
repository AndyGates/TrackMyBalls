using UnityEngine;
using System.Collections;
using Emgu.CV;
using Uk.Org.Adcock.Parallel;

public static class CVTextureUtility
{
	public static void UpdateWithMat(this Texture2D texture, Mat image)
	{
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
		
		texture.SetPixels(textureColors);
		texture.Apply();
	}
}
