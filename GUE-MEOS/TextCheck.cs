using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GUE_MEOS
{

    public class TextCheck
    {
        Topology topology = new Topology();
        int Ot;
        int Do;
        public List<double> Tex(string tes, int _Ot, int _Do, string DetectedTypeGraf)
        {
            Ot = _Ot;
            Do = _Do;
            string good = "";
            List<double> ResOtv = new List<double>();
            int caunot = 0;
            int caunpos = 0;
            //test.Text = Convert.ToString(tes.Length);
            for (int i = 0; i < tes.Length; i++)
            {
                if (tes.Length > 0)
                    if (tes[i] == '*')
                    {
                        good += " * ";
                    }
                    else if (tes[i] == '+')
                    {
                        good += " + ";
                    }
                    else if (tes[i] == '/')
                    {
                        good += " / ";
                    }
                    else if (tes[i] == '(')
                    {
                        good += " ( ";
                        caunot++;
                    }
                    else if (tes[i] == ')')
                    {
                        good += " ) ";
                        caunpos++;
                    }
                    else if (tes[i] == '^')
                    {
                        good += " ^ ";
                    }
                    else if (tes[i] == '-')
                    {
                        if (i > 0)
                        {
                            if (tes[i - 1] == '*' || tes[i - 1] == '+' || tes[i - 1] == '-' || tes[i - 1] == '/' || tes[i - 1] == '^' || tes[i - 1] == '(')
                                good += "-";
                            else
                                good += " - ";
                        }
                        else
                            good += "-";

                    }

                    else
                    {
                        good += tes[i];

                    }
                //test.Text = good;
                else
                {
                    good = "";
                }


            }

            if (good != "" && DetectedTypeGraf == "F" && caunpos == caunot)
            {
                if (!(good[good.Length - 1] == '*' || good[good.Length - 1] == ' ' || good[good.Length - 1] == '-'))
                {
                    ResOtv = Formul(good);
                }
            }
            else if (good != "" && DetectedTypeGraf == "P" && caunpos == caunot)
            {
                if (!(good[good.Length - 1] == '*' || good[good.Length - 1] == ' ' || good[good.Length - 1] == '-'))
                {
                    ResOtv = Formul(good);
                }
            }
            return ResOtv;

        }
        public static List<string> ToRPN(string initialString, string ran)
        {
            // В стеке будут содержаться операции из выражения
            string lastOperation;
            Stack<string> operationsStack = new Stack<string>();
            initialString = initialString.Replace("x", ran);
            initialString = initialString.Replace("t", ran);
            initialString = initialString.Replace("--", "");
            initialString = initialString.Trim();
            //if (initialString[0] == '+')
            //    initialString = initialString.Trim(new char[] { '+' });
            String pattern = @"([ ])";
            string[] initialStri = Regex.Split(initialString, pattern);
            //List<string> inin = new List<string>();
            //for (int i = 0; i < gf.Length; i++)
            //    inin.Add(gf[i]);
            //string[] initialStri = new string[inin.Count];
            //for (int i = 0; i < inin.Count; i++)
            //    inin.Remove(" ");
            //for (int i = 0; i < inin.Count; i++)
            //{
            //    initialStri[i] = inin[i];
            //test.Text += initialStri[i] + "|";
            //}
            var result = new List<string>();
            // Удаляем из входной строки лишние пробелы
            //initialString = initialString.Replace(" ", "");

            for (int i = 0; i < initialStri.Length; i++)
            {
                // Если текущий символ - число, добавляем его к результирующей строке
                double res;
                if (Double.TryParse(initialStri[i], out res))
                {
                    result.Add(initialStri[i]);
                    continue;
                }

                // Если текущий символ - операция (+, -, *, /)
                //
                if (IsOperation(initialStri[i]))
                {
                    // Если это не первая операция в выражении,
                    // то нам необходимо будет сравнить ее
                    // с последней операцией, хранящейся в стеке.
                    // Для этого сохраняем ее в переменной lastOperation
                    //
                    if (!(operationsStack.Count == 0))
                        lastOperation = operationsStack.Peek();

                    // Иначе (если это первая операция), кладем ее в стек,
                    // и переходим к следующему символу
                    else
                    {
                        operationsStack.Push(initialStri[i]);
                        continue;
                    }

                    // Если приоритет текущей операции больше приоритета
                    // последней, хранящейся в стеке, то кладем ее в стек
                    //
                    if (GetOperationPriority(lastOperation) < GetOperationPriority(initialStri[i]))
                    {
                        operationsStack.Push(initialStri[i]);
                        continue;
                    }

                    // иначе, выталкиваем последнюю операцию,
                    // а текущую сохраняем в стек
                    else
                    {
                        result.Add(operationsStack.Pop());
                        operationsStack.Push(initialStri[i]);
                        continue;
                    }
                }

                // Если текущий символ - '(', кладем его в стек
                if (initialStri[i].Equals("("))
                {
                    operationsStack.Push(initialStri[i]);
                    continue;
                }

                // Если текущий символ - ')', то выталкиваем из стека
                // все операции в результирующую строку, пока не встретим знак '('.
                // Его в строку не закидываем.
                if (initialStri[i].Equals(")"))
                {
                    while (operationsStack.Peek() != "(")
                    {
                        result.Add(operationsStack.Pop());
                    }
                    operationsStack.Pop();
                }
            }

            // После проверки всей строки, выталкиваем из стека оставшиеся операции
            while (!(operationsStack.Count == 0))
            {
                result.Add(operationsStack.Pop());
            }

            // Возвращаем результат
            return result;
        }

        /// <summary>
        /// Вычисляет результат выражения, записанного в обратной польской нотации
        /// </summary>
        /// <param name="rpnString"> Обратная польская запись выражения </param>
        /// <returns> Результат выражения </returns>
        public static double CalculateRPN(List<string> rpnString)
        {
            // В стеке будут храниться цифры из ОПН
            Stack<double> numbersStack = new Stack<double>();

            double op1, op2;

            for (int i = 0; i < rpnString.Count; i++)
            {
                double res;
                if (double.TryParse(rpnString[i], out res))
                {
                    numbersStack.Push(int.Parse(rpnString[i].ToString()));

                    // иначе (символ - операция), выполняем эту операцию
                    // для двух последних значений, хранящихся в стеке.
                    // Результат помещаем в стек
                }
                else
                {
                    op2 = numbersStack.Pop();
                    op1 = numbersStack.Pop();
                    numbersStack.Push(ApplyOperation(rpnString[i], op1, op2));
                }
            }

            // Возвращаем результат
            return numbersStack.Pop();
        }

        /// <summary>
        /// Проверяет, является ли символ математической операцией
        /// </summary>
        /// <param name="c"> Символ для проверки</param>
        /// <returns> true, если символ - операция, иначе false</returns>
        private static bool IsOperation(string c)
        {
            if (c == "+" ||
                c == "-" ||
                c == "*" ||
                c == "/" ||
                c == "^")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Определяет приоритет операции
        /// </summary>
        /// <param name="c"> Символ операции </param>
        /// <returns> Ее приоритет </returns>
        private static int GetOperationPriority(string c)
        {
            switch (c)
            {
                case "+": return 1;
                case "-": return 1;
                case "*": return 2;
                case "/": return 2;
                case "^": return 3;
                default: return 0;
            }
        }

        /// <summary>
        /// Выполняет матем. операцию над двумя числами
        /// </summary>
        /// <param name="operation"> Символ операции </param>
        /// <param name="op1"> Первый операнд </param>
        /// <param name="op2"> Второй операнд </param>
        /// <returns> Результат операции </returns>
        private static double ApplyOperation(string operation, double op1, double op2)
        {
            switch (operation)
            {
                case "+": return (op1 + op2);
                case "-": return (op1 - op2);
                case "*": return (op1 * op2);
                case "/": return (op1 / op2);
                case "^": return (Math.Pow(op1, op2));
                default: return 0;
            }
        }
        public List<double> Formul(string Formula)
        {
            var ResOtv = new List<double>();

            for (int j = Ot; j <= Do; j++)
            {
                List<string> result = ToRPN(Formula, Convert.ToString(j));
                for (int i = 0; i < result.Count; i++)
                {
                    //test.Text += result[i] + "|";
                    //test.Text += "Iin " + i;
                }
                ResOtv.Add(CalculateRPN(result));
                //Test.Text += " " + CalculateRPN(result);
            }
            return ResOtv;

        }
    }
}
