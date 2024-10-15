using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    public class ControllerBase
    {

        public virtual void Render(ViewBase view) { view.Render(); }
        public virtual void Render<T>(ViewBase<T> view, string path = "", bool both = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                view.Render();
                return;
            }

            if (both)
            {
                view.Render();
                view.RenderToFile(path);
                return;
            }
            view.RenderToFile(path);
        }

        public virtual void Render(Message message) => Render(new MessageView(message));
        public virtual void Success(string text, string lable = "Success") => Render(new Message { Type = MessageType.success, Text = text, Lable = lable });
        public virtual void Error(string text, string lable = "Error") => Render(new Message { Type = MessageType.error, Text = text, Lable = lable });
        public virtual void Information(string text, string lable = "Information") => Render(new Message { Type = MessageType.information, Text = text, Lable = lable });
        public virtual void Confirmation(string text, string backroute , string lable = "Confirmation"  ) => Render(new Message { Type = MessageType.confirmation, Text = text, Lable = lable , BackRoute = backroute });


    }
}
