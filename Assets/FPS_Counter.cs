using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Counter : MonoBehaviour
{

	public int AverageFPS{	get; private set;}
	public int HighestFPS { get; private set; }
	public int LowestFPS
	{
		get; private set;
	}
	// Start is called before the first frame update
	int[] fpsBuffer;
	int fpsBufferIndex;
	public int frameRange = 60;
	void Start()
    {
        
    }
	void InitializeBuffer()
	{
		if (frameRange <= 0)
		{
			frameRange = 1;
		}
		fpsBuffer = new int[frameRange];
		fpsBufferIndex = 0;
	}
	// Update is called once per frame
	void Update()
    {
		if (fpsBuffer == null || fpsBuffer.Length != frameRange)
		{
			InitializeBuffer();
		}
		UpdateBuffer();
		CalculateFPS();
	}
	void UpdateBuffer()
	{
		fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
		if (fpsBufferIndex >= frameRange)
		{
			fpsBufferIndex = 0;
		}
	}
	void CalculateFPS()
	{
		int sum = 0;
		int highest = 0;
		int lowest = int.MaxValue;
		for (int i = 0; i < frameRange; i++)
		{
			int fps = fpsBuffer[i];
			sum += fps;
			if (fps > highest)
			{
				highest = fps;
			}
			if (fps < lowest)
			{
				lowest = fps;
			}
		}
		AverageFPS = sum / frameRange;
		HighestFPS = highest;
		LowestFPS = lowest;
	}
}
