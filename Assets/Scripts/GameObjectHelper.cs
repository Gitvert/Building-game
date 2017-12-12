using UnityEngine;
using System;

//Static class that provide some helper methods to ease GameObject management in Unity.
public static class GameObjectHelper
{
	/// <summary>
	/// Finds the game object with the supplied tag. Throws an argument exception if a
	/// game object with the supplied tag is not found.
	/// </summary>
	/// <returns>The game object with the supplied tag.</returns>
	/// <param name="tag">The tag.</param>
	public static GameObject findWithTag(string tag)
	{
		GameObject gameObject = null;
		try
		{
			gameObject = GameObject.FindGameObjectWithTag(tag);
		}
		catch(UnityException ex)
		{
			var message = string.Format ("The tag {0} is not defined.", tag);
			throw new ArgumentException(message);
		}
		if(gameObject == null)
		{
			var message = string.Format ("A game object with tag \"{0}\" (name: {1}) could not be found", tag, gameObject.name);
			throw new ArgumentException(message);
		}
		return gameObject;
	}

	/// <summary>
	/// Finds the game object with the supplied name. Throws an argument exception if no game
	/// object with the supplied name is found
	/// </summary>
	/// <param name="name">The name of the game object.</param>
	public static GameObject findInScene(string name)
	{
		var gameObject = GameObject.Find (name);
		if(gameObject == null)
		{
			var message = string.Format ("Game object {0} could not be found.", name);
			throw new ArgumentException(message);
		}
		return gameObject;
	}

	/// <summary>
	/// Finds the game object with the supplied name. Only searches below parent in the hierarchy
	/// </summary>
	/// <param name="parent">A transform to limit the search to - only children of this transform will be searched.</param>
	/// <param name="name">The name of the game object to find.</param>
	public static GameObject findChild(GameObject parent, string name)
	{
		var child = parent.transform.Find (name);
		if(child == null)
		{
			var message = string.Format ("{1} does not have any child with the name {0}", name, parent);
			throw new ArgumentException(message);
		}
		return child.gameObject;
	}

	/// <summary>
	/// Gets the component of the specified type from the specified game object.
	/// Throws an ArgumentException if no such component is attached to the game object.
	/// </summary>
	/// <returns>The component of type T attached to the specified game object</returns>
	/// <param name="gameObject">The game object.</param>
	/// <typeparam name="T">The type of the component to fetch>typeparam>
	public static T getComponent<T>(GameObject gameObject) where T : Component
	{
		var component = gameObject.GetComponent<T>();
		if(component == null)
		{
			var message = string.Format ("Game object \"{0}\" does not have a component of type \"{1}\"", gameObject.name, typeof(T).ToString());
			throw new ArgumentException(message);
		}
		return component;
	}
}