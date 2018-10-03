using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateStackEvent();

//Create a generic class as an Observer
class ObservableStack<T> : Stack<T>
{
	public event UpdateStackEvent OnPush;
	public event UpdateStackEvent OnPop;
	public event UpdateStackEvent OnClear;

	// ----- call the basefunctions from Stack and add more functionality
	public new void Push(T item)
	{
		base.Push(item);

		if(OnPush != null)
			OnPush();
	}

	public new T Pop()
	{
		T item = base.Pop();

		if(OnPop != null)
			OnPop();

		return item;
	}

	public new void Clear()
	{
		base.Clear();

		if(OnClear != null)
			OnClear();
	}
}
