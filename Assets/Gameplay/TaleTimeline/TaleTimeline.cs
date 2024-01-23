using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaleTimeline : MonoBehaviour
{
	private IEnumerator m_TimelineCoroutine;
	[SerializeField] private string m_StartTale;

	public string CurrentTale { get; protected set; }
	private Part m_Part;
	
	private void Awake()
	{
		m_Part = GetComponentInChildren<Part>();
		NextTale(m_StartTale);
	}

/*	private IEnumerator TimelineRoutine(string taleName)
	{
		
		yield return new WaitUntil(()=>);
		
	}*/

	public void NextTale(string taleName)
	{
		CurrentTale = taleName;
		m_Part.Introduce(Instantiate(Resources.Load<Tale>($"Tales/{taleName}")), this);

	}
}
