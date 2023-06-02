using System;

namespace KillZombie.GUI
{
    class MenuItem
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public event EventHandler Click;

        public MenuItem(string name)
        {
            Name = name;
            Active = true;
        }

        public void OnClick()
        {
            if (Click != null)
                Click(this, null);
        }
    }
}
