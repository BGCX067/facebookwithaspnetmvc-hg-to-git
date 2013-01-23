using System;
using Facebook.Infrastructure.Crosscutting.Logging;

namespace Facebook.Infrastructure.Contracts
{
    public static class ContractUtil
    {
        public static void NotNull<T>(T obj) where T : class 
        {
            if (!Equals(obj, null)) 
                return;

            // Improve the following code:
            //  - maybe add the string to the resources
            //  - (...)

            Logger.Warn("Contract violation !!!");
            throw new ContractViolationException();
        }

        public static void IsNull<T>(T obj) where T : class
        {
            if (Equals(obj, null))
                return;

            // Improve the following code:
            //  - maybe add the string to the resources
            //  - (...)

            Logger.Warn("Contract violation !!!");
            throw new ContractViolationException();
        }

        public static void IsDefault<T>(T obj) where T : struct
        {
            if(Equals(obj, default(T)))
                return;

            Logger.Warn("Contract violation !!!");
            throw new ContractViolationException();
        }

        public static void IsInRange(int x, int lower = int.MinValue, int upper = int.MaxValue)
        {
            if (lower <= x && x <= upper)
                return;

            Logger.Warn("Contract violation !!!");
            throw new ContractViolationException();
        }
    }
}
