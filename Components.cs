using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface Component
    {
    }
    public struct Position : Component { }

    class Components
    {
        public Component[] components { get; private set; }
        public bool HasComponent<T>() where T : Component
        {
            return components.Any(e => e.GetType() == typeof(T));
        }

        public bool TryGetComponent<T>(out T comp) where T : Component, new()
        {
            var result = components.Where(e => e.GetType() == typeof(T));
            if (result.Any())
            {
                comp = (T)result.First();
                return true;
            }
            comp = new T();
            return false;
        }
        public void DoThing()
        {
            Position p;
            if (TryGetComponent<Position>(out p))
            {
                //Do something with p;
            }
            //Continue;
        }

    }
}
