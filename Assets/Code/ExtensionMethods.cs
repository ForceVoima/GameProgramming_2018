using UnityEngine;
using System;

namespace TankGame
{
	public static class ExtensionMethods
	{
		public static TComponent GetOrAddComponent< TComponent >( this GameObject gameObject )
			where TComponent : Component
		{
			TComponent component = gameObject.GetComponent< TComponent >();
			if ( component == null )
			{
				component = gameObject.AddComponent< TComponent >();
			}
			return component;
		}

		public static Component GetOrAddComponent( this GameObject gameObject, Type type )
		{
			Component component = gameObject.GetComponent( type );
			if ( component == null )
			{
				component = gameObject.AddComponent( type );
			}
			return component;
		}

        public static TComponent GetComponentInInactiveParents<TComponent>
            (this GameObject gameObject)
            where TComponent : Component
        {
            //return gameObject.transform.root.gameObject.GetComponentInChildren<TComponent>();
            
            TComponent result = null;

            if (gameObject.transform == gameObject.transform.root)
                return null;
            else
                result = gameObject.transform.parent.GetComponent<TComponent>();

            Debug.Log("Parent = " + gameObject.transform.parent.gameObject);

            if (result != null)
            {
                return result;
            }
            else
            {
                if (gameObject.transform.parent != null)
                    return gameObject.transform.parent.gameObject.GetComponentInInactiveParents<TComponent>();
                else
                    return null;
            }
        }

        public static TComponent GetComponentInHierarchy<TComponent>
            (this GameObject gameObject, bool includeInactive = false)
            where TComponent : Component
        {
            TComponent result = null;

            // In the gameObject itself:
            result = gameObject.GetComponent<TComponent>();

            if (result != null)
                return result;

            // In children:
            result = gameObject.GetComponentInChildren<TComponent>(includeInactive);

            if (result != null)
                return result;

            // In the parent:
            result = gameObject.GetComponentInInactiveParents<TComponent>();

            return result;
        }
    }
}
