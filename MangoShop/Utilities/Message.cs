namespace MangoShop.Utilities
{
    public class Message
    {
        private string _content;
        public Message(string content)
        {
            this._content = content;
        }
        public override string ToString()
        {
            return this._content;
        }
    }
}