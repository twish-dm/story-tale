/*using DG.Tweening;
using UnityEngine;


public class AnimateNone : AnimateBase
{
	public override void DoAnimate(Part part, AnimateInfo to)
	{
		CompleteHandler();
	}
	protected void CompleteHandler()
	{
		IsComplete = true;
		IsStart = false;
	}
}
public class AnimateHide : AnimateBase
{
	public override void DoAnimate(Part part, AnimateInfo to)
	{
		this.part = part;
		IsComplete = false;
		IsStart = true;
		this.part.Splash.color = to.Color;
		this.part.Splash.DOKill();
		this.part.Splash.DOFade(1, to.Duration).OnComplete(CompleteHandler);
	}
	protected void CompleteHandler()
	{
		IsComplete = true;
		IsStart = false;
	}
}
public class AnimateShow : AnimateBase
{
	public override void DoAnimate(Part part, AnimateInfo to)
	{
		this.part = part;
		IsComplete = false;
		IsStart = true;
		this.part.Splash.color = to.Color;
		this.part.Splash.DOKill();
		this.part.Splash.DOFade(0, to.Duration).OnComplete(CompleteHandler);
	}
	protected void CompleteHandler()
	{
		IsComplete = true;
		IsStart = false;
	}
}*/