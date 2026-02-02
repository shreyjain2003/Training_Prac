using System;

namespace ShopValidator
{
    public class GadgetValidatorUtil
    {
        public bool validateGadgetID(string gadgetID)
        {
            if(char.IsUpper(gadgetID[0]))
            {
                string[] parts=gadgetID.Split();
                for(int i = 1;i <= 3; i++)
                {
                    if(int.TryParse(parts[i],out int n))
                    {
                        continue;
                    }
                    else
                    {
                        throw new InvalidGadgetException($"Invalid gadget ID");
                    }
                }
                return true;
            }
            else
            {
                throw new InvalidGadgetException("Invalid gadget ID");
            }
        }
        public bool validateWarrentyPeriod(int warrantyPeriod)
        {
            if(warrantyPeriod >= 6 && warrantyPeriod <= 36)
            {
                return true;
            }
            else
            {
                throw new InvalidGadgetException("Invalid warranty period");
            }
        }
    }
    public class InvalidGadgetException : Exception
    {
        public InvalidGadgetException(string message): base(message)
        {
            
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            
            try
            {
                
                GadgetValidatorUtil gadgetValidatorUtil=new GadgetValidatorUtil();  
                Console.WriteLine("Enter the number of gadget entries: ");
                int number=int.Parse(Console.ReadLine());
                
                for( int i=0;i<number;i++)
                {
                    Console.WriteLine("Enter the Gadget details (gadgetD:gadgetType:warrantyPeriod) ");
                    string gadgetDetails=Console.ReadLine();
                    string[] parts=gadgetDetails.Split(":");
                    string gadgetID=parts[0];
                    string gadgetType=parts[1];
                    string warrantyPeriod=parts[2];
                    Console.WriteLine($"Enter gadget {i+1} details");
                    bool isValidGadgetID=gadgetValidatorUtil.validateGadgetID(gadgetID);
                    bool isValidWarrantyPeriod=gadgetValidatorUtil.validateWarrentyPeriod(int.Parse(warrantyPeriod));
                    if(isValidGadgetID && isValidWarrantyPeriod)
                    {
                        Console.WriteLine("Gadget details are valid");
                    }
                }
                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch(InvalidGadgetException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}