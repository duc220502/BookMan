using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    public enum MessageType { success , error , information , confirmation }
    public class Message
    {
        public MessageType Type { get; set; } = MessageType.success;
        public string Lable {  get; set; }

        public string Text { get; set; } = "Your action has completed successfully";
        public string BackRoute { get; set; }
    }
    public class MessageView : ViewBase<Message>
    {
        public MessageView(Message model) : base(model)
        {
        }

        public override void Render()
        {
            switch (Model.Type)
            {
                case MessageType.success :
                    ViewHelp.WriteLine(Model.Lable != null ? Model.Lable.ToUpper() : "Success", ConsoleColor.Green);
                    break;
                case MessageType.error:
                    ViewHelp.WriteLine(Model.Lable != null ? Model.Lable.ToUpper() : "Error", ConsoleColor.Red);
                    break;
                case MessageType.information:
                    ViewHelp.WriteLine(Model.Lable != null ? Model.Lable.ToUpper() : "Information", ConsoleColor.Blue);
                    break;
                case MessageType.confirmation:
                    ViewHelp.WriteLine(Model.Lable != null ? Model.Lable.ToUpper() : "Confirmation", ConsoleColor.Yellow);
                    break;
                default :
                    break;
            }
            

            if(Model.Type != MessageType.confirmation)
            {
                ViewHelp.WriteLine(Model.Text , ConsoleColor.White);
            }
            else
            {
                ViewHelp.WriteLine(Model.Text, ConsoleColor.Magenta);

                var answer = Console.ReadLine().ToLower();
                
                if(answer == "yes" || answer == "y")
                {
                    Console.WriteLine(Model.BackRoute);
                    Router.Forward(Model.BackRoute);
                }
            }


        }
    }
}
