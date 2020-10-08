using System;
using System.Collections.Generic;

public class NumberOperations
{
    public int BinaryToDecimal(int binaryNumber)
    {
        return Convert.ToInt32(binaryNumber.ToString(), 2);
    }

    public int BinaryToDecimal(string binaryNumber)
    {
        return Convert.ToInt32(binaryNumber, 2);
    }

    public string DecimalToBinary(int decimalNumber)
    {
        string result = Convert.ToString(decimalNumber, 2);

        while(result.Length < 4)
        {
            result = "0" + result;
        }

        return result;
    }

    public Stack<int> SplitDigits(string number)
    {
        //Cria a pilha que vai conter os dígitos separados
        Stack<int> splitDigits = new Stack<int>();
        /*
        //Fiz com um "do while" para ele rodar pelo menos uma vez
        do
        {
            //Insere o resto da divisão à pilha. O resto sempre é o último dígito do número
            splitDigits.Push(number % 10);
            
            //Tira o último dígito do número
            number /= 10;
        }
        while (number > 0);
        */

        for(int i = 0; i < number.Length; i++)
        {
            splitDigits.Push(int.Parse(number[i].ToString()));
        }
        return splitDigits;
    }
}
