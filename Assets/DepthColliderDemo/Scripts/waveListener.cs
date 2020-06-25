using UnityEngine;
using System.Collections;
using System;

public class waveListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;

	private bool wave;


	public bool IsWave()
	{
		if (wave)
		{
			wave = false;
			return true;
		}

		return false;
	}



	public void UserDetected(uint userId, int userIndex)
	{
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.Wave);

		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "Wave to lose flower";
		}
	}

	public void UserLost(uint userId, int userIndex)
	{
		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture,
								  float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		// don't do anything here
	}

	public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
								  KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = sGestureText;
		}

		if (gesture == KinectGestures.Gestures.Wave)
			wave = true;

		return true;
	}

	public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture,
								  KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}

}
