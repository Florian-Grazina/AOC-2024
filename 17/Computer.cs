﻿using System.Reflection;

namespace _17
{
    internal class Computer
    {
        public List<short> Data { get; set; }


        public Computer(List<short> data)
        {
            Data = data;
        }

        public void Run()
        {
            for (int i = 0; i < Data.Count;)
            {
                if(i + 1 == Data.Count)
                    break;

                short id = Data[i];
                short operand = Data[i + 1];

                OpeCode opeCode = GetOpeCode(id, operand);
                short offset = opeCode.Execute();

                if(opeCode is Out)
                    if (AreListsEqualFast(Register.Outputs, Register.ListRef))
                        break;

                if (offset == 99)
                    i += 2;
                else
                    i = offset;
            }
        }

        private OpeCode GetOpeCode(short id, short operand)
        {
            return id switch
            {
                0 => new Adv(operand),
                1 => new Bxl(operand),
                2 => new Bst(operand),
                3 => new Jnz(operand),
                4 => new Bxc(operand),
                5 => new Out(operand),
                6 => new Bdv(operand),
                7 => new Cdv(operand),
                _ => throw new Exception("Invalid OpCode"),
            };
        }

        private bool AreListsEqualFast(IList<int> list1, IList<int> list2)
        {
            if (list1 == null || list2 == null || list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    return false;
            }

            return true;
        }
    }
}
