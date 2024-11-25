using System;

namespace FactoryMethod
{
    // Product
    public abstract class Message
    {
        public abstract void Send();
    }

    // Concrete Products
    public class EmailMessage : Message
    {
        public override void Send() => Console.WriteLine("Sending Email Message...");
    }

    public class SMSMessage : Message
    {
        public override void Send() => Console.WriteLine("Sending SMS Message...");
    }

    public class ViberMessage : Message
    {
        public override void Send() => Console.WriteLine("Sending Viber Message...");
    }

    // Creator
    public abstract class MessageFactory
    {
        public abstract Message CreateMessage();
    }

    // Concrete Creators
    public class EmailFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new EmailMessage();
        }
    }

    public class SMSFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new SMSMessage();
        }
    }

    public class ViberFactory : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new ViberMessage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a factory for each message type
            MessageFactory emailFactory = new EmailFactory();
            MessageFactory smsFactory = new SMSFactory();
            MessageFactory viberFactory = new ViberFactory();

            // Create and send messages
            Message email = emailFactory.CreateMessage();
            email.Send();

            Message sms = smsFactory.CreateMessage();
            sms.Send();

            Message push = viberFactory.CreateMessage();
            push.Send();

            Console.ReadKey();
        }
    }
}