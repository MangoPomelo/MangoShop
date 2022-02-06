using System;

namespace MangoShop.Utilities
{
    public class Argument
    {
        private ushort _parsedID;
        private byte _parsedAmount;
        public Argument(string[] command) {
            try {
                // Parse ID
                this._parsedID = Convert.ToUInt16(command[0]);
                // Parse amount (default as 1)
                this._parsedAmount = Convert.ToByte(command.Length >= 2 ? command[1] : "1");
            } catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException || ex is OverflowException) {
                throw new ArgumentException("Given command is invalid");
            }
        }
        public ushort GetID() {
            return this._parsedID;
        }
        public byte GetAmount() {
            return this._parsedAmount;
        }
    }
}