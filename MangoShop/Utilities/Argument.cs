using System;

namespace MangoShop.Utilities
{
    public class Argument
    {
        public string Name;
        public byte Amount;

        public Argument(string defaultName = "", byte defaultAmount = 1) {
            this.Name = defaultName;
            this.Amount = defaultAmount;
        }

        public Argument Parse(string[] command)
        {
            try
            {
                // Parse the first argument as Name (Necessary)
                if (command.Length <= 0)
                {
                    throw new FormatException("Missing name field which is necessary");
                }
                this.Name = command.Length >= 1 ? command[0] : this.Name;

                // Parse the second argument as Amount (Optional)
                this.Amount = command.Length >= 2 ? Convert.ToByte(command[1]) : this.Amount;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new FormatException("Error occurs when parsing argument");
            }

            return this;
        }
    }
}