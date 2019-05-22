using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Net2_2_new
{
    public class User : IEnumerable<Window>
    {
        private readonly List<Window> _windows;

        public string Name { get; }

        public User(string name)
        {
            Name = name;
            _windows = new List<Window>();
        }

        public string GetIncorrectLogins()
        {
            var flag = false;
            var haveMain = false;

            foreach (var window in _windows)
            {
                if (window.Title == "main")
                {
                    haveMain = true;
                    if (window.Top == null || window.Left == null
                                           || window.Width == null || window.Height == null)
                    {
                        flag = true;
                    }
                }
            }

            return flag || haveMain == false ? Name : null;
        }

        public void Add(Window windows)
        {
            _windows.Add(windows);
        }

        public List<Window> GetWindows()
        {
            return _windows;
        }


        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Login: {Name}");
            foreach (var window in _windows) result.AppendLine(window.ToString());
            return result.ToString();
        }

        public IEnumerator<Window> GetEnumerator()
        {
            return _windows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}